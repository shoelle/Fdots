module Flib.PaddleMovementData

open Unity.Entities

[<GenerateAuthoringComponent>]
[<Struct>]
type PaddleMovementData =
    interface IComponentData
    val mutable direction : int
    val speed : float32