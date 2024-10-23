using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct ShootPointComponent
    {
        public float tick;
        public float timer;
        public Transform point;
    }
}