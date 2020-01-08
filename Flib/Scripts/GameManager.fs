module Flib.GameManager

open System.Collections
open Unity.Entities
open Unity.Mathematics
open Unity.Physics
open UnityEngine
open UnityEngine.UI

type GameManager () =
    inherit MonoBehaviour()

    let mutable ballEntityPrefab : Entity = null
    let mutable manager : EntityManager = null

    let oneSecond = new WaitForSeconds(1.0f)
    let delay = new WaitForSeconds(respawnDelay)
    //public static GameManager main;

    member val ballPrefab: GameObject = null with get, set

    member val xBound: float = 3.f with get, set
    member val yBound: float = 3.f with get, set
    member val ballSpeed: float = 3.f with get, set
    member val respawnDelay: float = 2.f with get, set
    member val playerScores: int[] = [] with get, set

    member val mainText: Text = "" with get, set
    member val playerTexts: Text[] = [] with get, set


    member this.Awake() =
        (*if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }*)

        //main <- this;
        this.playerScores <- [0,0]

        this.manager <- World.DefaultGameObjectInjectionWorld.EntityManager

        let settings : GameObjectConversionSettings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null)
        this.ballEntityPrefab <- GameObjectConversionUtility.ConvertGameObjectHierarchy(this.ballPrefab, settings);

        StartCoroutine CountdownAndSpawnBall;


    member this.PlayerScored(playerID : int) =
        this.playerScores[playerID] <- this.playerScores[playerID] + 1;
        for i = 0 to playerScores.Length do // && i < playerTexts.Length; i++)
            this.playerTexts[i].text <- this.playerScores[i].ToString();

        StartCoroutine CountdownAndSpawnBall
    

    member this.CountdownAndSpawnBall() =
        this.mainText.text <- "Get Ready"
        yield return this.delay

        this.mainText.text <- "3"
        yield return this.oneSecond;

        this.mainText.text <- "2"
        yield return this.oneSecond

        this.mainText.text <- "1"
        yield return this.oneSecond

        this.mainText.text <- ""

        SpawnBall
   

    member this.SpawnBall() =
    
        let ball : Entity = this.manager.Instantiate ballEntityPrefab

        let x = if UnityEngine.Random.Range(0, 2) = 0 then -1 else 1
        let y = UnityEngine.Random.Range(-0.5f, 0.5f)
        let dir = new Vector3(x, y, 0.f).normalized;
        Vector3 speed = dir * ballSpeed;

        let velocity : PhysicsVelocity = // new PhysicsVelocity()
            {Linear = speed; Angular = float3.zero }

        this.manager.AddComponentData(ball, velocity);
    


