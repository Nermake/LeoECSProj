using ECS.Components;
using ECS.Flags;
using ECS.Tags;
using Leopotam.Ecs;
using Logic.View;
using Services;
using Zenject;

namespace ECS.Systems
{
    public sealed class CursorTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityTargetComponent, PlayerTag> _filter;
        
        [Inject] private readonly CursorTarget _cursorTarget;
        
        private ActorView _last;

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