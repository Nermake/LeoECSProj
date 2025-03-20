using Leopotam.Ecs;
using Zenject;

namespace ECS.Systems
{
    public sealed class InitializeInputControllerSystem : IEcsInitSystem
    {
        [Inject] private readonly InputController _inputController;
        
        public void Init() => _inputController.Game.Enable();
    }
}