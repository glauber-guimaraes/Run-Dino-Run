using Unity.Entities;

public struct JumpOptions : IComponentData
{
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpVelocity;
    public float gravity;
}