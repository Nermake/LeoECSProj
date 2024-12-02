using System;
using System.Collections.Generic;
using Game.Types;
using Logic.View;
using UnityEngine;

namespace Services.Factory.Builders
{
    public class EntityConfig : ScriptableObject
    {
        [field: Header("UnitResource")]
        [field: SerializeField] public List<UnitResource> UnitResources { get; private set; }
        
        [field: Header("View")]
        [field: SerializeField] public ActorView ActorView { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }//

        [field: Header("Team")]
        [field: SerializeField] public Team Team { get; private set; }

        public virtual EntityBuilder GetBuilder()
        {
            return new EntityBuilder(this);
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