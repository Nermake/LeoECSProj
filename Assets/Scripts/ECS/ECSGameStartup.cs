using ECS.Data;
using ECS.Events;
using ECS.Systems;
using Factory;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS
{
    public class ECSGameStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private RuntimeData _runtimeData;
    
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _systemsForFixedUpdate;

        private SceneData _sceneData;
        private InputController _inputController;

        private EntityFactory _entityFactory;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systemsForFixedUpdate = new EcsSystems(_world);

            _sceneData = gameObject.GetComponent<SceneData>();
            _runtimeData = new RuntimeData();
            _inputController = new InputController();
            _entityFactory = new EntityFactory();

            _systems.ConvertScene();

            _runtimeData.Init();
            
            AddInjections();
            AddOneFrames();
            AddSystems();
        
            _systems?.Init();
            _systemsForFixedUpdate?.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _systemsForFixedUpdate?.Run();
        }

        private void AddInjections()
        {
            _systems.
                Inject(_sceneData).
                Inject(_staticData).
                Inject(_runtimeData).
                Inject(_inputController).
                Inject(_entityFactory)
                ;

            _systemsForFixedUpdate.
                Inject(_sceneData).
                Inject(_staticData).
                Inject(_runtimeData)
                ;
        }
    
        private void AddOneFrames()
        {
            _systems.OneFrame<TestEvent>();
        }
    
        private void AddSystems()
        {
            _systems.
                Add(new PlayerInitializeSystem()).
                Add(new InitializeInputControllerSystem()).
                Add(new PlayerInputSystem()).
                Add(new EntityInitializeSystem()).
                Add(new SetTargetForEnemySystem()).
                Add(new SpawnEnemySystem())
                //Add(new DebugTransformEntitySystem())
                ;

            _systemsForFixedUpdate.
                Add(new MovementSystem()).
                Add(new FollowSystem());
        }
    
        private void OnDestroy()
        {
            if (_systems == null) return;
            if (_systemsForFixedUpdate == null) return;

            _runtimeData = null;
            
            _systems.Destroy();
            _systems = null;

            _systemsForFixedUpdate.Destroy();
            _systemsForFixedUpdate = null;
        
            _world.Destroy();
            _world = null;
        }
    }
}
