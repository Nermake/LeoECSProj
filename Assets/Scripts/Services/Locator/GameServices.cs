using System.Collections.Generic;
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
        private InputController _inputController;
        
        public void Init(EcsWorld world)
        {
            _actorFactory = new ActorFactory(world);
            _inputController = new InputController();
            
            RegisterServices();
            InitServices();
            AddDisposables();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
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