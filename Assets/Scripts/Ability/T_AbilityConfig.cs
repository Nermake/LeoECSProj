using UnityEngine;

namespace Ability
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Game Data/Test/Ability Config", order = 0)]
    public class T_AbilityConfig : ScriptableObject
    {
        [field : SerializeField] public string ID { get; private set; }
        [field : SerializeField] public string Title { get; private set; }
        [field : SerializeField] public sbyte Level { get; private set; }
        [field : SerializeField] public string Description { get; private set; }
        [field : SerializeField] public Sprite DisplayImage { get; private set; }
        
        [field : SerializeField] public float CooldownTime { get; private set; }
        [field : SerializeField] public float CastTime { get; private set; }
        
        [field : SerializeField] public float ResourceCost { get; private set; }
        [field : SerializeField] public EResourceCostType ResourceType { get; private set; }
        
        [field : SerializeField] public EAbilityType AbilityType { get; private set; }
        [field : SerializeField] public EAbilityOgType AbilityOgType { get; private set; }
        [field : SerializeField] public EBuffDebuffType BuffDebuffType { get; private set; }
        [field : SerializeField] public EAbilityVectorType AbilityVectorType { get; private set; }
        
        [field : SerializeField] public KeyCode HotKey { get; private set; }
    }
}