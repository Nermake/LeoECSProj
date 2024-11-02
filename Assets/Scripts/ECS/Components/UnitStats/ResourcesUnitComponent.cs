using System;

namespace ECS.Components
{
    [Serializable]
    public struct ResourcesUnitComponent
    {
        public float health;
        public float mana;
        public float energy;

        public static ResourcesUnitComponent operator +(ResourcesUnitComponent a, ResourcesUnitComponent b)
        {
            return new ResourcesUnitComponent()
            {
                health = a.health + b.health,
                mana = a.mana + b.mana,
                energy = a.energy + b.energy
            };
        }
    }
}