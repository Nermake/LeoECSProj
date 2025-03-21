using ECS.Components;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;
using View;
using Zenject;

namespace ECS.Systems
{
    public sealed class SetGoldSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GoldComponent, AddGoldEvent> _addGoldFilter;
        private readonly EcsFilter<GoldComponent, RemoveGoldEvent> _removeGoldFilter;
        private readonly EcsFilter<ChangeGoldEvent> _changeGoldFilter;

        private readonly GoldPanelView _goldPanelView;
        
        public SetGoldSystem(DiContainer container)
        {
            _goldPanelView = container.Resolve<SceneData>().GoldPanelView;
        }
        
        public void Run()
        {
            foreach (var i in _addGoldFilter)
            {
                ref var entity = ref _addGoldFilter.GetEntity(i);
                
                ref var goldComponent = ref _addGoldFilter.Get1(i);
                ref var addGoldEvent = ref _addGoldFilter.Get2(i);
                
                goldComponent.Amount += addGoldEvent.Amount;
                
                entity.Get<ChangeGoldEvent>().Amount = goldComponent.Amount;
                entity.Del<AddGoldEvent>();
            }

            foreach (var i in _removeGoldFilter)
            {
                ref var entity = ref _removeGoldFilter.GetEntity(i);
                
                ref var goldComponent = ref _removeGoldFilter.Get1(i);
                ref var removeGoldEvent = ref _removeGoldFilter.Get2(i);

                if (goldComponent.Amount < removeGoldEvent.Amount)
                {
                    Debug.LogError($"[{nameof(SetGoldSystem)}] : attempt to subtract more than possible \n" +
                                   $"|>===> now: {goldComponent.Amount}\n" +
                                   $"|>===> remove: {removeGoldEvent.Amount}\n");
                }
                else
                {
                    goldComponent.Amount -= removeGoldEvent.Amount;
                                    
                    entity.Get<ChangeGoldEvent>().Amount = goldComponent.Amount;
                }
                entity.Del<RemoveGoldEvent>();
            }

            foreach (var i in _changeGoldFilter)
            {
                ref var changeGoldEvent = ref _changeGoldFilter.Get1(i);
                
                _goldPanelView.SetGoldAmount(changeGoldEvent.Amount);
                _changeGoldFilter.GetEntity(i).Del<ChangeGoldEvent>();
            }
        }
    }
}