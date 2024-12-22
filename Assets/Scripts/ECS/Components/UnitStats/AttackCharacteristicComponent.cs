namespace ECS.Components
{
    public struct AttackCharacteristicComponent
    {
        public float AttackPower;
        public float SpellPowerDamage;
        
        public float Accuracy;
        public float ArmorPenetrationRate;
        public float PenetratingPowerOfSpells;

        public float ChanceOfCriticalHit;
        public float PowerOfCriticalHit;

        public static AttackCharacteristicComponent operator +(AttackCharacteristicComponent a, AttackCharacteristicComponent b)
        {
            return new AttackCharacteristicComponent()
            {
                AttackPower = a.AttackPower + b.AttackPower,
                SpellPowerDamage = a.SpellPowerDamage + b.SpellPowerDamage,
                
                Accuracy = a.Accuracy + b.Accuracy,
                ArmorPenetrationRate = a.ArmorPenetrationRate + b.ArmorPenetrationRate,
                PenetratingPowerOfSpells = a.PenetratingPowerOfSpells + b.PenetratingPowerOfSpells,
                
                ChanceOfCriticalHit = a.ChanceOfCriticalHit + b.ChanceOfCriticalHit,
                PowerOfCriticalHit = a.PowerOfCriticalHit + b.PowerOfCriticalHit
            };
        }

        public override string ToString()
        {
            var massage = $"AttackPower: {AttackPower} \n" +
                      $"SpellPowerDamage: {SpellPowerDamage} \n" +
                      $"Accuracy: {Accuracy} \n" +
                      $"ArmorPenetrationRate: {ArmorPenetrationRate} \n" +
                      $"PenetratingPowerOfSpells: {PenetratingPowerOfSpells} \n" +
                      $"ChanceOfCriticalHit: {ChanceOfCriticalHit} \n" +
                      $"PowerOfCriticalHit: {PowerOfCriticalHit}";
            
            return massage;
        }
    }
}