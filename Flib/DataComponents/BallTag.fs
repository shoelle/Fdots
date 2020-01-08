module Flib.BallTag

open Unity.Entities;
open System
open System.Runtime.CompilerServices

[<GenerateAuthoringComponent>]
[<Struct>]  // is this enough tagging? should these also be IsByRefLike??  see https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/byrefs#byref-like-structs
type BallTag =
    interface IComponentData
        