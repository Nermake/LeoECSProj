using System;
using ECS.Systems;
using Leopotam.Ecs;
using Zenject;

namespace ECS
{
    public class EcsSystemLauncher : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly DiContainer _container;
        private EcsSystems _systems;
        
        public EcsSystemLauncher(EcsSystems systems, DiContainer container)
        {
            _systems = systems;
            _container = container;
        }
        
        public void Initialize()
        {
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
            _systems?.FixedRun();
        }

        public void LateTick()
        {
            _systems?.LateRun();
        }
    
        private void AddRunSystems()
        {
            _systems.
                Add(new InitializeEntitySystem()).
                Add(new InitializeCameraSystem(_container)).
                Add(new InitializeInputControllerSystem(_container)).
                Add(new PlayerInputSystem(_container)).
                Add(new SetTargetForCameraSystem(_container)).
                Add(new CameraFollowSystem(_container)).
                Add(new SetTargetForEnemySystem(_container)).
                Add(new RemovesProhibitionMoveSystem()).
                
                Add(new AbilityReadinessSystem()).
                Add(new AbilityInputSystem(_container)).
                Add(new AbilityApplySystem()).
                Add(new AbilityWasteSystem()).
                Add(new AbilityCooldownSystem()).
                Add(new AbilityStartCastSystem(_container)).
                Add(new AbilityRunCastSystem(_container)).
                Add(new AbilityFinishCastSystem(_container)).
                
                Add(new ImplementerSystem()).
                Add(new EffectPeriodicSystem()).
                
                Add(new BuffHealSystem()).
                
                Add(new EffectDurationSystem()).
                Add(new ImplementerDestroySystem()).
                
                //Add(new GenerateProjectileSystem()).
                Add(new SetTargetForProjectileSystem()).
                Add(new RegenerationUnitSystem()).
                Add(new SetGoldSystem(_container)).
                Add(new SetRaceSystem(_container)).
                Add(new SetColorSecondaryResourceSystem()).
                Add(new ResourcePlateSystem()).
                Add(new ResourceFrameSystem()).
                Add(new UnitLevelSystem(_container)).
                Add(new UnitLevelViewSystem(_container)).
                Add(new DeathSystem(_container))
                ;
        }

        private void AddFixedRunSystems()
        {
            _systems.
                Add(new ProjectileMovementSystem(_container)).
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
        }
    }
}
