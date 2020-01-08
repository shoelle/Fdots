open Unity.Entities;
open System.Runtime.CompilerServices

[<GenerateAuthoringComponent>]
[<IsByRefLike; Struct>]
type BallTag =
    inherit IComponentData()
    