using System;
using Ability;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct AbilityComponent
    {
        public string title;
        public string description;
        public Sprite icon;

        public float cooldownTime;
        public float cooldownTimer;

        public float resourceCost;
        public ResourceCostType resourceType;
    }
}

