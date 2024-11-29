using Ability.Effects;

namespace Ability.Interface
{
    public interface IAbilityAddEffect<T> where T : Effect
    {
        T Effect { get; set; }
        void AddEffect();
    }
}