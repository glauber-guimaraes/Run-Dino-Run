using System;
using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;

#if !UNITY_WEBGL
using InputSystem = Unity.Tiny.GLFW.GLFWInputSystem;
#else
    using InputSystem =  Unity.Tiny.HTML.HTMLInputSystem;
#endif

public class PlayerJumpSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var input = EntityManager.World.GetExistingSystem<InputSystem>();
        var isJumpPressed = input.GetKey(Unity.Tiny.Input.KeyCode.Space) || input.GetMouseButton(0);

        float dt = World.TinyEnvironment().frameDeltaTime;

        var jumpOptions = GetSingleton<JumpOptions>();

        Entities.ForEach((ref Translation transformPosition, ref Player player) =>
        {
            // Player is on the ground.
            if (player.VerticalVelocity == 0f && isJumpPressed) {
                player.VerticalVelocity = jumpOptions.jumpVelocity;
            }

            if (player.VerticalVelocity < 0f) {
                player.GravityScale = jumpOptions.fallMultiplier;
            } else if (player.VerticalVelocity > 0f && isJumpPressed == false) {
                player.GravityScale = jumpOptions.lowJumpMultiplier;
            } else {
                player.GravityScale = 1f;
            }

            player.VerticalVelocity += jumpOptions.gravity * player.GravityScale * dt;
            var position = transformPosition.Value;
            position.y += player.VerticalVelocity * dt;

            // TODO: Properly collide with the floor.
            if (position.y < 0f) {
                position.y = 0f;
                player.VerticalVelocity = 0f;
            }

            transformPosition.Value = position;
            Console.WriteLine($"Final position = {transformPosition.Value}.");

        });
    }
}
