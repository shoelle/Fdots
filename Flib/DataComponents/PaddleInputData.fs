module Flib.PaddleInputData

open Unity.Entities
open UnityEngine

[<GenerateAuthoringComponent>]
[<Struct>] // IsByRefLike??
type PaddleInputData =
    interface IComponentData
    val upKey : KeyCode
    val downKey : KeyCode
