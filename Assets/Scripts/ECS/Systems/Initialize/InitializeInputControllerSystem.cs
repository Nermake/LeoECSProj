using Leopotam.Ecs;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class InitializeInputControllerSystem : IEcsInitSystem
    {
        public void Init() => ServiceLocator.Current.Get<InputController>().Game.Enable();
    }
}