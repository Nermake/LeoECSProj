using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct CameraFollowComponent
    {
        public Transform target;
        public Vector3 offset;
        public float smoothing;
    }
}