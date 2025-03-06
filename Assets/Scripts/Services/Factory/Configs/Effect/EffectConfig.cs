using UnityEngine;

namespace Services.Factory
{
    public class EffectConfig : ScriptableObject
    {
        [field: Header("Data")]
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField, TextArea(3, 10)] public string Description { get; private set; }
        
        public virtual EffectBuilder GetBuilder()
        {
            return new EffectBuilder(this);
        }
    }
}