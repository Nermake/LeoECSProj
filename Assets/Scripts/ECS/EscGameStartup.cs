using ECS.Data;
using ECS.Events;
using ECS.Systems;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;
using Voody.UniLeo;

namespace ECS
{
    public class EscGameStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private GameServices _gameServices; // todo
        
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _systemsForFixedUpdate;

        private SceneData _sceneData;
        private RuntimeData _runtimeData;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _gameServices.Init(_world);
            
            _systemsForFixedUpdate = new EcsSystems(_world);

            _sceneData = gameObject.GetComponent<SceneData>();
            
            _runtimeData = new RuntimeData();

            _systems.ConvertScene();

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
                Inject(_runtimeData)
                ;

            _systemsForFixedUpdate.
                Inject(_sceneData).
                Inject(_staticData).
                Inject(_runtimeData)
                ;
        }
    
        private void AddOneFrames()
        {
            _systems.OneFrame<DeathEvent>();
        }
    
        private void AddSystems()
        {
            _systems.
                Add(new InitializeEntitySystem()).
                Add(new InitializePlayerSystem()).
                Add(new InitializeInputControllerSystem()).
                Add(new PlayerInputSystem()).
                Add(new SetTargetForEnemySystem()).
                //Add(new SpawnEnemySystem()).
                Add(new RemovesProhibitionMoveSystem()).
                Add(new GenerateProjectileSystem()).
                Add(new SetTargetForProjectileSystem()).
                Add(new RegenerationUnitSystem()).
                Add(new SetResourceViewSystem()).
                Add(new ResourceViewSystem()).
                //Add(new T_SpawnPlayerSystem()).
                Add(new DeathSystem())
                ;

            _systemsForFixedUpdate.
                Add(new ProjectileMovementSystem()).
                Add(new PlayerMovementSystem()).
                Add(new FollowSystem())
                ;
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
