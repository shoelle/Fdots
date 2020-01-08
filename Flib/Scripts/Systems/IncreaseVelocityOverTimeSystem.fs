open Unity.Entities
open Unity.Jobs
open Unity.Mathematics
open Unity.Physics

[<AlwaysSynchronizeSystem>]
type IncreaseVelocityOverTimeSystem () =
    inherit JobComponentSystem()

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    member this.OnUpdate(inputDeps: JobHandle) =
    
        let deltaTime = Time.DeltaTime

        Entities.ForEach((ref PhysicsVelocity vel, in SpeedIncreaseOverTimeData data) =>
        {
            float2 modifier = new float2(data.increasePerSecond * deltaTime)

            float2 newVel = vel.Linear.xy
            newVel += math.lerp(-modifier, modifier, math.sign(newVel))
            vel.Linear.xy = newVel
        }).Run()

        this.default
