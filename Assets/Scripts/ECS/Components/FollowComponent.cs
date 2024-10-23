using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct FollowComponent
    {
        public Vector2 target;
        public Vector2 targetDirection;
        public float distanceToStop;
    }
}