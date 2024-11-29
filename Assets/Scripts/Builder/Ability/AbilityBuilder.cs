using Data;

namespace Ability
{
    public class AbilityBuilder
    {
        private readonly AbilityData _data;
        protected Ability ability;

        public AbilityBuilder(AbilityData data)
        {
            _data = data;
        }
        
        public virtual void Make()
        {
            if (ability != null)
            {
                ability.SetID(_data.ID);
                ability.SetDescription(_data.Title, _data.Description, _data.Icon);
                ability.SetCooldown(_data.Cooldown);
                ability.SetResource(_data.ResourceCost, _data.ResourceType);
                
                ability.ChangeStatus(AbilityStatus.Ready);
            }
        }

        public virtual Ability GetResult() => ability;
    }
}