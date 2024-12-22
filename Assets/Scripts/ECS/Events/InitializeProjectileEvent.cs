using UnityEngine;

namespace ECS.Events
{
    public struct InitializeProjectileEvent
    {
        public Vector3 Target;
        public Vector3 StartPosition;
    }
}