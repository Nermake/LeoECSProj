using Game.Types;
using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "ResourceBuffConfig", menuName = "Game/Buff/Resource Config")]
    public class ResourceBuffConfig : BuffConfig
    {
        [field: Header("Resource")]
        [field: SerializeField] public UnitResourcesType Type { get; private set; }
        [field: SerializeField] public float Pool { get; private set; }
        [field: SerializeField] public float Regeneration { get; private set; }
        [field: SerializeField] public float Reduction { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new ResourceBuffBuilder(this);
        }
    }
}