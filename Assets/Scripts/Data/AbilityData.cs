using Ability;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AbilityData", menuName = "Game Data/Ability/Data", order = 0)]
    public class AbilityData : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public float CooldownTimer  { get; private set; }
        [field: SerializeField] public float ResourceCost  { get; private set; }
        [field: SerializeField] public ResourceCostType ResourceType { get; private set; }
        [field: SerializeField] public AbilityStatus Status { get; private set; }
        
        public AbilityBuilder GetBuilder() => new(this);
    }
}