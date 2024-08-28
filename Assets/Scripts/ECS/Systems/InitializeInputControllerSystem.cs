using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class InitializeInputControllerSystem : IEcsInitSystem
    {
        private readonly InputController _inputController = null;

        public void Init() => _inputController.Game.Enable();
    }
}