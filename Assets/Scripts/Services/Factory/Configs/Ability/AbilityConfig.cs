using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Game/Ability Config")]
    public class AbilityConfig : ScriptableObject
    {
        [field: Header("Data")]
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField, TextArea(5, 10)] public string Description { get; private set; }
        [field: SerializeField] public float CooldownTime { get; private set; }
        [field: SerializeField] public float CastTime { get; private set; }
        [field: SerializeField] public float ResourceCost { get; private set; }
        [field: SerializeField] public UnitResourcesType ResourcesType { get; private set; }
        [field: SerializeField] public KeyCode KeyCode { get; private set; }
        
        [field: Header("View")]
        [field: SerializeField] public Sprite Icon { get; private set; }
        
        [field: Header("Effects")]
        [field: SerializeField] public List<EffectConfig> EffectConfigs { get; private set; }

        public virtual AbilityBuilder GetBuilder()
        {
            return new AbilityBuilder(this);
        }
    }
}