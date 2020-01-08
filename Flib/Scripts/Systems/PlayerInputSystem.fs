open Unity.Entities
open Unity.Jobs
open UnityEngine

[<AlwaysSynchronizeSystem>]
type PlayerInputSystem () =
    inherit JobComponentSystem()

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    member this.OnUpdate(inputDeps: JobHandle) =
    
        this.Entities.ForEach((ref PaddleMovementData moveData, in PaddleInputData inputData) =>
        {
            let up = if Input.GetKey(inputData.upKey) then 1 else 0
            let down = if Input.GetKey(inputData.downKey) then 1 else 0
            moveData.direction <- up - down
        }).Run()

        this.default
