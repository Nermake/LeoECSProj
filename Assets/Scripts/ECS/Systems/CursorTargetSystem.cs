using ECS.Components;
using ECS.Flags;
using ECS.Tags;
using Leopotam.Ecs;
using Logic.View;
using Services;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class CursorTargetSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<AbilityTargetComponent, PlayerTag> _filter;
        
        private CursorTarget _cursorTarget;
        private ActorView _last;
        
        public void Init()
        {
            _cursorTarget = ServiceLocator.Current.Get<CursorTarget>();
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var actorViewComponent = ref _filter.Get1(i).Target.Get<ActorViewComponent>();
                
                _last = actorViewComponent.ActorView;

                if (_cursorTarget.TryGetView(out actorViewComponent.ActorView))
                {
                    if (_last != actorViewComponent.ActorView)
                    {
                        _last.GetEntity().Del<CursorTargetFlag>();
                        _last = actorViewComponent.ActorView;
                    }
                    
                    _last.GetEntity().Get<CursorTargetFlag>();
                }
                else
                {
                    _last.GetEntity().Del<CursorTargetFlag>();
                }
            }
        }
    }
}