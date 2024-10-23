using ECS.Components;
using ECS.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class EnemyRangeBuilder : EnemyEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            base.Setup(unit);

            entity.Get<RangeAttackFlag>();
            ref var shootPointComponent = ref entity.Get<ShootPointComponent>();
            ref var followComponent = ref entity.Get<FollowComponent>();
            
            shootPointComponent.tick = 2f;
            shootPointComponent.point = unit.transform;
            
            followComponent.distanceToStop = 1.5f;
        }
    }
}