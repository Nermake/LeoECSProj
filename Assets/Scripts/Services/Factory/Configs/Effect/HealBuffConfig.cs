using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "HealBuffConfig", menuName = "Game/Buff/Heal Config")]
    public class HealBuffConfig : BuffConfig
    {
        [field: Header("Heal")]
        [field: SerializeField] public float Amount { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new HealBuffBuilder(this);
        }
    }
}