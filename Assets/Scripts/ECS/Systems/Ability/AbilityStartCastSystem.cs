using ECS.Components;
using ECS.Data;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using View;
using Zenject;

namespace ECS.Systems
{
    public sealed class AbilityStartCastSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityStartCastEvent> _startCsatFilter;
        
        private AbilityCastView _view;

        [Inject]
        private void Construct(SceneData sceneData)
        {
            _view = sceneData.AbilityCastView;
        }
        
        public void Run()
        {
            foreach (var i in _startCsatFilter)
            {
                ref var entity = ref _startCsatFilter.GetEntity(i);

                if (entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Free
                    || entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Instant)
                {
                    entity.Get<AbilityFinishCastEvent>();
                    entity.Del<AbilityStartCastEvent>();
                }

                if (entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Clear
                    || entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Normal)
                {
                    entity.Get<AbilityRunCastEvent>();
                    entity.Del<AbilityStartCastEvent>();
                    
                    _view.Show();
                    _view.SetImage(entity.Get<AbilityComponent>().Icon);
                }
            }
        }
    }
}