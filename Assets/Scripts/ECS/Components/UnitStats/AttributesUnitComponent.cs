using System;

namespace ECS.Components
{
    [Serializable]
    public struct AttributesUnitComponent
    {
        public int strength;
        public int agility;
        public int intelligence;
        
        public static AttributesUnitComponent operator +(AttributesUnitComponent a, AttributesUnitComponent b)
        {
            return new AttributesUnitComponent()
            {
                strength = a.strength + b.strength,
                agility = a.agility + b.agility,
                intelligence = a.intelligence + b.intelligence,
            };
        }
    }
}