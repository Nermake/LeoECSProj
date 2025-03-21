using Leopotam.Ecs;
using Zenject;

namespace ECS.Systems
{
    public sealed class InitializeInputControllerSystem : IEcsInitSystem
    {
        private readonly InputController _inputController;
        
        public InitializeInputControllerSystem(DiContainer container)
        {
            _inputController = container.Resolve<InputController>();
        }
        
        public void Init() => _inputController.Game.Enable();
    }
}