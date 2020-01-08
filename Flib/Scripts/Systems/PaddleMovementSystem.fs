open Unity.Entities
open Unity.Jobs
open Unity.Mathematics
open Unity.Transforms

[<AlwaysSynchronizeSystem>]
type PaddleMovementSystem () =
    inherit JobComponentSystem()

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    member this.OnUpdate(inputDeps : JobHandle)
    
        let deltaTime = Time.DeltaTime
        let yBound = GameManager.main.yBound

        this.Entities.ForEach((ref Translation trans, in PaddleMovementData data) =>
        {
            trans.Value.y = math.clamp(trans.Value.y + (data.speed * data.direction * deltaTime), -yBound, yBound);
        }).Run()

        this.default