using Unity.Entities;

/*
 * A little explanation about the values of gravity and jumpVelocity found in the inspector :
 * 
 * Instead of trying value by value until the jump feels right, we can just use the physics formulas
 * with the desired jump behaviour to compute those values.
 * 
 * For the equations of movement we have that:
 * v = v_0 + a*t 
 * v^2 = (v_0)^2 + 2*a*deltaS
 * 
 * As we're only interested in the vertical component (a = gravity), we can define 2 constants for the jump :
 * | t_max - Time until maximum height
 * | s_max - Maximum height during the jump
 * 
 * If we substitute both into the original equations, when the height is maximum, i.e. v = 0:
 * 0 = jumpVelocity + gravity * t_max
 * 0 = (jumpVelocity)^2 + 2 * gravity * s_max
 * 
 * Solving those 2 equations gives the gravity and jumpVelocity.
 */

public struct JumpOptions : IComponentData
{
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpVelocity;
    public float gravity;
}