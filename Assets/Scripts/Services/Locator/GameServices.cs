using ECS.Data;
using Leopotam.Ecs;
using Services.Factory;
using UnityEngine;
using View;

namespace Services.Locator
{
    public class GameServices : MonoBehaviour
    {
        [SerializeField] private Destroyer _destroyer;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;
        
        private ActorFactory _actorFactory;
        private RuntimeData _runtimeData;
        private InputController _inputController;
        
        public void Init(EcsWorld world)
        {
            _actorFactory = new ActorFactory(world);
            _runtimeData = new RuntimeData();
            _inputController = new InputController();
            
            RegisterServices();
            InitServices();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Current.Register(_runtimeData);
            ServiceLocator.Current.Register(_actorFactory);
            ServiceLocator.Current.Register(_inputController);
            ServiceLocator.Current.Register(_destroyer);
            ServiceLocator.Current.Register(_staticData);
            ServiceLocator.Current.Register(_sceneData);
        }

        private void InitServices()
        {
            
        }
    }
}