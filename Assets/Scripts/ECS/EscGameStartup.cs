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
        [SerializeField] private GameServices _gameServices; // todo
        
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _systemsForFixedUpdate;
        
        private RuntimeData _runtimeData;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systemsForFixedUpdate = new EcsSystems(_world);
            _runtimeData = new RuntimeData();
            _gameServices.Init(_world, _runtimeData);

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
            // _systems.
            //     Inject().
            //     Inject()
            //     ;
            //
            // _systemsForFixedUpdate.
            //     Inject().
            //     Inject()
            //     ;
        }
    
        private void AddOneFrames()
        {
            _systems.OneFrame<DeathEvent>();
        }
    
        private void AddSystems()
        {
            _systems.
                Add(new InitializeEntitySystem()).
                Add(new InitializeCameraSystem()).
                Add(new InitializeInputControllerSystem()).
                Add(new PlayerInputSystem()).
                Add(new SetTargetForCameraSystem()).
                Add(new CameraFollowSystem()).
                Add(new SetTargetForEnemySystem()).
                //Add(new SpawnEnemySystem()).
                Add(new RemovesProhibitionMoveSystem()).
                Add(new GenerateProjectileSystem()).
                Add(new SetTargetForProjectileSystem()).
                Add(new RegenerationUnitSystem()).
                Add(new SetGoldSystem()).
                Add(new SetRaceSystem()).
                Add(new SetResourceSystem()).
                Add(new ResourceViewSystem()).
                Add(new UnitLevelSystem()).
                Add(new UnitLevelViewSystem()).
                Add(new DeathSystem())
                ;

            _systemsForFixedUpdate.
                Add(new ProjectileMovementSystem()).
                Add(new PlayerMovementSystem()).
                Add(new UnitFollowSystem())
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
