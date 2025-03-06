using System;
using System.Collections.Generic;
using Game.Types;
using Logic.View;
using UnityEngine;

namespace Services.Factory
{
    public class UnitConfig : ScriptableObject
    {
        [field: Header("UnitResource")]
        [field: SerializeField] public List<UnitResource> UnitResources { get; private set; }
        [field: SerializeField] public UnitResourcesType SecondaryResource { get; private set; }
        
        [field: Header("View")]
        [field: SerializeField] public ActorView ActorView { get; private set; }

        public virtual UnitBuilder GetBuilder()
        {
            return new UnitBuilder(this);
        }
    }

    [Serializable]
    public struct UnitResource
    {
        public float max;
        public float current;
        public float regeneration;
        
        public UnitResourcesType type;
    }
}