using UnityEngine;

namespace Ability
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Sprite DisplayImage { get; private set; }
        public float CooldownTime { get; private set; }
        //public float CooldownTimer { get; private set; }
        public float ResourceCost { get; private set; }
        public EResourceCostType ResourceType { get; private set; }
        public KeyCode HotKey { get; private set; }
        
        public AbilityBuilder GetBuilder() => new AbilityBuilder(this);
    }
}