module Flib.IncreaseVelocityOverTimeSystem

open Unity.Entities
open Unity.Jobs
open Unity.Mathematics
open Unity.Physics

open SpeedIncreaseOverTimeData

[<AlwaysSynchronizeSystem>]
type IncreaseVelocityOverTimeSystem () =
    inherit JobComponentSystem()
    
    override this.OnUpdate(inputDeps: JobHandle) =
    
        let deltaTime = this.Time.DeltaTime

        this.Entities.ForEach((fun (vel : ref<PhysicsVelocity>, data : SpeedIncreaseOverTimeData) -> // TODO - inref
        
            let modifier = new float2(data.increasePerSecond * deltaTime)

            let mutable newVel = vel.contents.Linear.xy
            newVel <- newVel + math.lerp(-modifier, modifier, math.sign(newVel))
            vel.contents.Linear.xy <- newVel
        )).Run()

        JobHandle()
