module Flib.PaddleMovementSystem

open Unity.Entities
open Unity.Jobs
open Unity.Mathematics
open Unity.Transforms

open PaddleMovementData
open GameManager

[<AlwaysSynchronizeSystem>]
type PaddleMovementSystem () =
    inherit JobComponentSystem()
    
    override this.OnUpdate(inputDeps : JobHandle) =
    
        let deltaTime = this.Time.DeltaTime
        let yBound = GameManager.main.yBound

        this.Entities.ForEach((fun (trans: ref<Translation>, data: PaddleMovementData) -> // TODO - inref
        
            trans.contents.Value.y <- math.clamp(trans.contents.Value.y +
                (data.speed * (float32 data.direction) * deltaTime), -yBound, yBound);
        )).Run()

        JobHandle()