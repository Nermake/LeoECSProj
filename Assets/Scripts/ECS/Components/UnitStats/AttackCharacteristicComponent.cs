using System;

namespace ECS.Components
{
    [Serializable]
    public struct AttackCharacteristicComponent
    {
        public float attackPower;
        public float spellPowerDamage;
        
        public float accuracy;
        public float armorPenetrationRate;
        public float penetratingPowerOfSpells;

        public float chanceOfCriticalHit;
        public float powerOfCriticalHit;

        public static AttackCharacteristicComponent operator +(AttackCharacteristicComponent a, AttackCharacteristicComponent b)
        {
            return new AttackCharacteristicComponent()
            {
                attackPower = a.attackPower + b.attackPower,
                spellPowerDamage = a.spellPowerDamage + b.spellPowerDamage,
                
                accuracy = a.accuracy + b.accuracy,
                armorPenetrationRate = a.armorPenetrationRate + b.armorPenetrationRate,
                penetratingPowerOfSpells = a.penetratingPowerOfSpells + b.penetratingPowerOfSpells,
                
                chanceOfCriticalHit = a.chanceOfCriticalHit + b.chanceOfCriticalHit,
                powerOfCriticalHit = a.powerOfCriticalHit + b.powerOfCriticalHit
            };
        }
    }
}