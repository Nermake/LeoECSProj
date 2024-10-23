using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct ProjectileTargetComponent
    {
        public Vector2 target;
    }
}