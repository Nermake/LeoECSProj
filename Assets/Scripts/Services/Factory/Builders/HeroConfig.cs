using ECS.Components;
using Game.Types;
using UnityEngine;

namespace Services.Factory.Builders
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Game/Hero Config")]
    public sealed class HeroConfig : EntityConfig
    {
        [field: Header("UnitRace")]
        [field: SerializeField] public AttributesUnitComponent RaceAttributes { get; private set; }
        [field: SerializeField] public RaceType RaceType { get; private set; }
        
        [field: Header("UnitClass")] 
        [field: SerializeField] public AttributesUnitComponent ClassAttributes { get; private set; }
        [field: SerializeField] public ClassType ClassType { get; private set; }
        
        public override EntityBuilder GetBuilder()
        {
            return new HeroBuilder(this);
        }
    }
}