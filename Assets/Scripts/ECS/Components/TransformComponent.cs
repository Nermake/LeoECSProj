using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct TransformComponent
    {
        public Transform modelTransform;
    }
}