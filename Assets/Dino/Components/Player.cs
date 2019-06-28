using Unity.Authoring.Core;
using Unity.Entities;

public struct Player : IComponentData
{
    [HideInInspector] public float VerticalVelocity;
    [HideInInspector] public float GravityScale;
}
