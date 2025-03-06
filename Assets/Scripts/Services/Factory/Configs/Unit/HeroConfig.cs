using ECS.Components;
using Game.Types;
using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Game/Hero Config", order = 0)]
    public sealed class HeroConfig : MovableUnitConfig
    {
        [field: Header("UnitRace")]
        [field: SerializeField] public RaceType RaceType { get; private set; }
        
        [field: Header("UnitClass")] 
        [field: SerializeField] public AttributesUnitComponent ClassAttributes { get; private set; } // todo
        [field: SerializeField] public ClassType ClassType { get; private set; }
        
        [field: Header("DefaultResources")]
        [field: SerializeField] public int Gold { get; private set; } // todo
        
        public override UnitBuilder GetBuilder()
        {
            return new HeroBuilder(this);
        }
    }
}