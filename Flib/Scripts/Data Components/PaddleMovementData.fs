using Unity.Entities;

[GenerateAuthoringComponent]
[<IsByRefLike; Struct>]
type PaddleMovementData () =
	inherit IComponentData

    public int direction;
    public float speed;

