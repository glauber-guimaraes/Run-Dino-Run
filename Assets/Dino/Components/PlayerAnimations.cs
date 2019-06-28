using Unity.Entities;

namespace Dino
{
    public struct PlayerAnimations : IComponentData
    {
        public Entity Walk;
        public Entity Jump;
        public Entity Dead;
    }
}