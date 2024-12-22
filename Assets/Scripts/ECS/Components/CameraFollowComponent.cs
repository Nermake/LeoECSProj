using UnityEngine;

namespace ECS.Components
{
    public struct CameraFollowComponent
    {
        public Transform Target;
        public Vector3 Offset;
        public float Smoothing;
    }
}