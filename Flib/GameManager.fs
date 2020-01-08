module Flib.GameManager

open System.Collections
open Unity.Entities
open Unity.Mathematics
open Unity.Physics
open UnityEngine
open UnityEngine.UI

type GameManager () =
    inherit MonoBehaviour()

    member val ballEntityPrefab : Entity = Entity.Null with get, set
    member val manager : EntityManager = null with get, set

    member val oneSecond : YieldInstruction = null with get, set
    member val delay : YieldInstruction = null with get, set
    static member val main : GameManager = GameManager() with get, set

    member val ballPrefab: GameObject = null with get, set

    member val xBound: float32 = 3.f with get, set
    member val yBound: float32 = 3.f with get, set
    member val ballSpeed: float32 = 3.f with get, set
    member val respawnDelay: float32 = 2.f with get, set
    member val playerScores: int[] = [||] with get, set

    member val mainText: Text = null with get, set
    member val playerTexts: Text[] = [||] with get, set

    
    member this.SpawnBall() =
    
        let ball : Entity = this.manager.Instantiate this.ballEntityPrefab

        let x = if UnityEngine.Random.Range(0, 2) = 0 then -1.f else 1.f
        let y = UnityEngine.Random.Range(-0.5f, 0.5f)
        let dir = new Vector3(x, y, 0.f) |> Vector3.Normalize
        let speed = dir * this.ballSpeed;

        let mutable velocity : PhysicsVelocity = PhysicsVelocity()
        // TODO - why is this necessary? vs { Linear = float3.op_Implicit(speed); Angular = float3.zero }
        velocity.Linear <- float3.op_Implicit(speed)
        velocity.Angular <- float3.zero

        this.manager.AddComponentData(ball, velocity) |> ignore
        
    
    member this.CountdownAndSpawnBall =
        seq {
            this.mainText.text <- "Get Ready"
            yield this.delay

            this.mainText.text <- "3"
            yield this.oneSecond;

            this.mainText.text <- "2"
            yield this.oneSecond

            this.mainText.text <- "1"
            yield this.oneSecond

            this.mainText.text <- ""

            this.SpawnBall ()
        } :?> IEnumerator
   
    member this.PlayerScored(playerID : int) =
        this.playerScores.[playerID] <- this.playerScores.[playerID] + 1;
        for i = 0 to this.playerScores.Length do // TODO && i < playerTexts.Length; i++)
            this.playerTexts.[i].text <- this.playerScores.[i].ToString();

        this.StartCoroutine(this.CountdownAndSpawnBall)
        
    member this.Awake() =
        (*if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }*)

        GameManager.main <- this;
        this.playerScores <- [|0; 0|]

        this.manager <- World.DefaultGameObjectInjectionWorld.EntityManager

        let settings : GameObjectConversionSettings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null)
        this.ballEntityPrefab <- GameObjectConversionUtility.ConvertGameObjectHierarchy(this.ballPrefab, settings);
        
        this.oneSecond <- new WaitForSeconds(1.f)
        this.delay <- new WaitForSeconds(this.respawnDelay)

        this.StartCoroutine(this.CountdownAndSpawnBall)


