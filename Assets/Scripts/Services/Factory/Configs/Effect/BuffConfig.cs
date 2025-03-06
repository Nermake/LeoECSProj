using UnityEngine;

namespace Services.Factory
{
    public class BuffConfig : EffectConfig
    {
        [field: Header("BuffInfo")]
        [field: SerializeField] public bool IsBuff { get; private set; }
        [field: SerializeField] public bool IsInstant { get; private set; }
        [field: SerializeField] public float TickInterval { get; private set; }
        [field: SerializeField] public float AmountPerTick { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        
        [field: Header("Calculate")]
        [field: SerializeField] public bool IsPercentage { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new BuffBuilder(this);
        }
    }
}