using System.Collections.Generic;
using ECS.Components;
using Game.Types;
using Logic.View;
using UnityEngine;

namespace Services.Factory.Builders
{
    public class HeroConfig : ScriptableObject
    {
        [field: Header("UnitResource")]
        [field: SerializeField] public List<UnitResource> UnitResources { get; private set; }
        
        [field: Header("UnitRace")]
        [field: SerializeField] public AttributesUnitComponent RaceAttributes { get; private set; }
        [field: SerializeField] public RaceType RaceType { get; private set; }
        
        [field: Header("UnitClass")] 
        [field: SerializeField] public AttributesUnitComponent ClassAttributes { get; private set; }
        [field: SerializeField] public ClassType ClassType { get; private set; }
        
        [field: Header("View")]
        [field: SerializeField] public ActorView ActorView { get; private set; }

        [field: Header("Team")]
        [field: SerializeField] public Team Team { get; private set; }
        
        public virtual HeroBuilder GetBuilder()
        {
            return new HeroBuilder(this);
        }
    }
}