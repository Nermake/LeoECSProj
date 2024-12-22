using UnityEngine;

namespace ECS.Components
{
    public struct UnitFollowComponent
    {
        public Vector2 Target;
        public Vector2 TargetDirection;
        public float DistanceToStop;
    }
}