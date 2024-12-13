using System.Collections.Generic;
using ECS.Data;
using Leopotam.Ecs;
using Services.Factory;
using UnityEngine;

namespace Services.Locator
{
    public class GameServices : MonoBehaviour
    {
        [SerializeField] private Destroyer _destroyer;
        
        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        
        private ActorFactory _actorFactory;
        private RuntimeData _runtimeData;
        private InputController _inputController;
        
        public void Init(EcsWorld world, RuntimeData runtimeData)
        {
            _actorFactory = new ActorFactory(world);
            _runtimeData = runtimeData;
            _inputController = new InputController();
            
            RegisterServices();
            InitServices();
            AddDisposables();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Current.Register(_runtimeData);
            ServiceLocator.Current.Register(_actorFactory);
            ServiceLocator.Current.Register(_inputController);
            ServiceLocator.Current.Register(_destroyer);
        }

        private void InitServices()
        {
            
        }

        private void AddDisposables()
        {
            
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

    }
}