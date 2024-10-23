using System;
using UnityEngine;

namespace ECS.Requests
{
    [Serializable]
    public struct InitializeProjectileRequest
    {
        public Vector3 target;
        public Vector3 startPosition;
    }
}