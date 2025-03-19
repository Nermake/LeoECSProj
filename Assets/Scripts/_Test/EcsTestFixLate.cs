using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace _Test
{
    public class EcsTestFixLate : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddSystems();
        
            _systems?.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _systems.FixedRun();
        }

        private void LateUpdate()
        {
            _systems.LateRun();
        }

        private void AddSystems()
        {
            _systems
                .Add(new RunSystem())
                .Add(new FixedRunSystem())
                .Add(new LateRunSystem());
        }
    
        private void OnDestroy()
        {
            if (_systems == null) return;
            
            _systems.Destroy();
            _systems = null;
        
            _world.Destroy();
            _world = null;
        }
    }

    public sealed class RunSystem : IEcsInitSystem, IEcsRunSystem
    {
        private int _counter = 0;
        
        public void Init()
        {
            Debug.Log($"[RunSys] Init: {_counter}");
        }
        
        public void Run()
        {
            _counter++;
            Debug.Log($"[RunSys] : {_counter}");
        }
    }

    public sealed class FixedRunSystem : IEcsInitSystem, IEcsFixedRunSystem
    {
        private int _counter = 0;
        
        public void Init()
        {
            Debug.Log($"[FixedRunSys] Init: {_counter}");
        }
        
        public void FixedRun()
        {
            _counter++;
            Debug.Log($"[FixedRunSys] : {_counter}");
        }
    }

    public sealed class LateRunSystem : IEcsInitSystem, IEcsLateRunSystem
    {
        private int _counter = 0;
        
        public void Init()
        {
            Debug.Log($"[LateRunSys] Init: {_counter}");
        }
        
        public void LateRun()
        {
            _counter++;
            Debug.Log($"[LateRunSys] : {_counter}");
        }
    }
}