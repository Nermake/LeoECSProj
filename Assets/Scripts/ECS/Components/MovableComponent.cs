using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody2D rigidbody2D;
        public float speed;
    }
}