using ECS.Components;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace Logic.View
{
    public class ActorView : EntityView
    {
        [field: SerializeField] public ResourcePanelView ResourcePanel { get; private set; }
        
        public virtual void ApplyDamage(Damage damage)
        {
            if (_entity.IsAlive() && _entity.Has<DamageableComponent>())
            {
                ref var damageableComponent = ref _entity.Get<DamageableComponent>();
                damageableComponent.damageQueue.Enqueue(damage);
            }
        }
    }
}