open Unity.Entities
open Unity.Transforms
open Unity.Collections
open Unity.Mathematics
open Unity.Jobs

[<AlwaysSynchronizeSystem>]
type BallGoalCheckSystem () =
    inherit JobComponentSystem()

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    member this.OnUpdate(inputDeps : JobHandle)
    
        let ecb = new EntityCommandBuffer(Allocator.TempJob)

        Entities
            .WithAll<BallTag>()
            .WithoutBurst()
            .ForEach((Entity entity, in Translation trans) =>
            {
                float3 pos = trans.Value;
                float bound = GameManager.main.xBound;

                if (pos.x >= bound)
                {
                    GameManager.main.PlayerScored(0)
                    ecb.DestroyEntity(entity)
                }
                else if (pos.x <= -bound)
                {
                    GameManager.main.PlayerScored(1)
                    ecb.DestroyEntity(entity)
                }
            }).Run()

        ecb.Playback(EntityManager)
        ecb.Dispose()

        return default