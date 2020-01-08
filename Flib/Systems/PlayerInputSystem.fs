module Flib.PlayerInputSystem

open Unity.Entities
open Unity.Jobs
open UnityEngine

open PaddleMovementData
open PaddleInputData

[<AlwaysSynchronizeSystem>]
type PlayerInputSystem () =
    inherit JobComponentSystem()
    
    override this.OnUpdate(inputDeps: JobHandle) : JobHandle =
    
        this.Entities.ForEach((fun (moveData: ref<PaddleMovementData>, inputData: PaddleInputData) -> // TODO - inref
        
            let up = if Input.GetKey(inputData.upKey) then 1 else 0
            let down = if Input.GetKey(inputData.downKey) then 1 else 0
            moveData.contents.direction <- up - down
        )).Run()

        JobHandle()
        

        
