using System;
using ECS.Systems;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace ECS
{
    public sealed class EscGameStartup : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public EscGameStartup(EcsWorld world, EcsSystems systems)
        {
            _world = world;
            _systems = systems;
        }
        
        public void Initialize()
        {
            _systems.ConvertScene();

            AddRunSystems();
            AddFixedRunSystems();
            AddLateRunSystems();
        
            _systems?.Init();
        }

        public void Tick()
        {
            _systems?.Run();
        }

        public void FixedTick()
        {
            //_systems?.FixedRun();
        }

        public void LateTick()
        {
            //_systems?.LateRun();
        }
    
        private void AddRunSystems()
        {
            _systems.
                Add(new InitializeEntitySystem()).
                Add(new InitializeCameraSystem()).
                Add(new InitializeInputControllerSystem()).
                Add(new PlayerInputSystem()).
                Add(new SetTargetForCameraSystem()).
                Add(new CameraFollowSystem()).
                Add(new SetTargetForEnemySystem()).
                Add(new RemovesProhibitionMoveSystem()).
                
                Add(new AbilityReadinessSystem()).
                Add(new AbilityInputSystem()).
                Add(new AbilityApplySystem()).
                Add(new AbilityWasteSystem()).
                Add(new AbilityCooldownSystem()).
                Add(new AbilityStartCastSystem()).
                Add(new AbilityRunCastSystem()).
                Add(new AbilityFinishCastSystem()).
                
                Add(new ImplementerSystem()).
                Add(new EffectPeriodicSystem()).
                
                Add(new BuffHealSystem()).
                
                Add(new EffectDurationSystem()).
                Add(new ImplementerDestroySystem()).
                
                //Add(new GenerateProjectileSystem()).
                Add(new SetTargetForProjectileSystem()).
                Add(new RegenerationUnitSystem()).
                Add(new SetGoldSystem()).
                Add(new SetRaceSystem()).
                Add(new SetColorSecondaryResourceSystem()).
                Add(new ResourcePlateSystem()).
                Add(new ResourceFrameSystem()).
                Add(new UnitLevelSystem()).
                Add(new UnitLevelViewSystem()).
                Add(new DeathSystem())
                ;
        }

        private void AddFixedRunSystems()
        {
            _systems.
                Add(new ProjectileMovementSystem()).
                Add(new PlayerMovementSystem()).
                Add(new UnitFollowSystem())
                ;
        }

        private void AddLateRunSystems()
        {
            
        }
    
        public void Dispose()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}
