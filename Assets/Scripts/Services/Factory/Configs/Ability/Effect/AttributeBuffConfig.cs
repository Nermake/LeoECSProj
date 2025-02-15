using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "AttributeBuffConfig", menuName = "Game/Buff/Attribute Config")]
    public class AttributeBuffConfig : BuffConfig
    {
        [field: Header("Attribute Buff")]
        [field: SerializeField] public int Strength { get; private set; }
        [field: SerializeField] public int Agility { get; private set; }
        [field: SerializeField] public int Intelligence { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new AttributeBuffBuilder(this);
        }
    }
}