module Flib.SpeedIncreaseOverTimeData

open Unity.Entities

[<GenerateAuthoringComponent>]
[<Struct>]
type SpeedIncreaseOverTimeData =
    interface IComponentData

    val increasePerSecond : float32
