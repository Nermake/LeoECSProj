using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "DefenseBuffConfig", menuName = "Game/Buff/Defense Config")]
    public class DefenseBuffConfig : BuffConfig
    {
        [field: Header("Defense")]
        [field: SerializeField] public float PhysicProtection { get; private set; }
        [field: SerializeField] public float Resistance { get; private set; }
        [field: SerializeField] public float Evasion { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new DefenseBuffBuilder(this);
        }
    }
}