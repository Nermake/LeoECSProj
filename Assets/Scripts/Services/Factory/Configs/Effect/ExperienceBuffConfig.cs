using UnityEngine;

namespace Services.Factory
{
    [CreateAssetMenu(fileName = "ExperienceBuffConfig", menuName = "Game/Buff/Experience Config")]
    public class ExperienceBuffConfig : BuffConfig
    {
        [field: Header("Experience")]
        [field: SerializeField] public float Amount { get; private set; }
        
        public override EffectBuilder GetBuilder()
        {
            return new ExperienceBuffBuilder(this);
        }
    }
}