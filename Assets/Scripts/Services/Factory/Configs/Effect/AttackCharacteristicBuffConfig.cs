using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "AttackCharacteristicBuffConfig", menuName = "Game/Buff/Attack Characteristic Config")]
    public class AttackCharacteristicBuffConfig : BuffConfig
    {
        [field: Header("Attack Characteristic Buff")]
        [field: SerializeField] public float AttackPower { get; private set; }
        [field: SerializeField] public float SpellPowerDamage { get; private set; }
        [field: SerializeField] public float Accuracy { get; private set; }
        [field: SerializeField] public float ArmorPenetrationRate { get; private set; }
        [field: SerializeField] public float PenetratingPowerOfSpells { get; private set; }
        [field: SerializeField] public float ChanceOfCriticalHit { get; private set; }
        [field: SerializeField] public float PowerOfCriticalHit { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new AttackCharacteristicBuffBuilder(this);
        }
    }
}