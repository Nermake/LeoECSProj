namespace Ability
{
    public class AbilityBuilder
    {
        private AbilityConfig _config;
        protected Ability _ability;

        public AbilityBuilder(AbilityConfig config)
        {
            _config = config;
        }

        public virtual void Make()
        {
            if (_ability != null)
            {
                _ability.SetDescription(_config.Title, _config.Description, _config.DisplayImage);
                _ability.SetCooldown(_config.CooldownTime);
                _ability.SetKey(_config.HotKey);
                //_ability.SetResourceCost(_config.ResourceCost, _config.ResourceType);
            }
        }

        public virtual Ability GetResult() => _ability;
    }
}