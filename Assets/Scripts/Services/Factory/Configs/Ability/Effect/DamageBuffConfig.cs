using Game.Types;
using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "DamageBuffConfig", menuName = "Game/Buff/Damage Config")]
    public class DamageBuffConfig : BuffConfig
    {
        [field: Header("Damage")]
        [field: SerializeField] public float Amount { get; private set; }
        [field: SerializeField] public bool IsAll { get; private set; }
        [field: SerializeField] public DamageType DamageType { get; private set; }
        [field: SerializeField] public MagicType MagicType { get; private set; }
    
        public override EffectBuilder GetBuilder()
        {
            return new DamageBuffBuilder(this);
        }
    }
}