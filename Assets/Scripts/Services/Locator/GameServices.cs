using System.Collections.Generic;
using Leopotam.Ecs;
using Services.Factory;
using UnityEngine;
using Voody.UniLeo;

namespace Services.Locator
{
    public class GameServices : MonoBehaviour
    {
        private ActorFactory _actorFactory;
        
        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Init(EcsWorld world)
        {
            _actorFactory = new ActorFactory(world);
            
            RegisterServices();
            Init();
            AddDisposables();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Current.Register(_actorFactory);
        }

        private void Init()
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