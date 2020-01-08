open Unity.Entities
open UnityEngine

[<GenerateAuthoringComponent>]
[<IsByRefLike; Struct>]
type PaddleInputData =
    inherit IComponentData()
    val upKey : KeyCode
    val downKey : KeyCode
