module Flib.BallGoalCheckSystem

open Unity.Entities
open Unity.Transforms
open Unity.Collections
open Unity.Mathematics
open Unity.Jobs

open BallTag
open GameManager

[<AlwaysSynchronizeSystem>]
type BallGoalCheckSystem () =
    inherit JobComponentSystem()
    
    override this.OnUpdate(inputDeps : JobHandle) =
    
        let ecb = new EntityCommandBuffer(Allocator.TempJob)

        this.Entities
            .WithAll<BallTag>()
            .WithoutBurst()
            .ForEach((fun (entity : Entity, trans : Translation) -> // TODO - trans should be inref - but illegal in IL???
            //.ForEach((fun (entity : Entity, trans : inref<Translation>) -> // TODO - uncomment this version for error, what's the right keyword??
            
                let pos = trans.Value
                let bound = GameManager.main.xBound

                if pos.x >= bound then
                    GameManager.main.PlayerScored(0) |> ignore
                    ecb.DestroyEntity(entity)
                else if pos.x <= -bound then
                    GameManager.main.PlayerScored(1) |> ignore
                    ecb.DestroyEntity(entity)
                
            )).Run()

        ecb.Playback(this.EntityManager)
        ecb.Dispose()

        JobHandle()