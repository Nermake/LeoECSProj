using ECS.Components;
using ECS.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class EnemyMileBuilder : EnemyEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            base.Setup(unit);

            entity.Get<MileAttackFlag>();

            ref var followComponent = ref entity.Get<FollowComponent>();

            followComponent.distanceToStop = 1.5f;
        }
    }
}