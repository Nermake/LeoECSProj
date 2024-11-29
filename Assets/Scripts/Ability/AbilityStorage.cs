using System.Collections.Generic;
using Data;

namespace Ability
{
    public class AbilityStorage
    {
        //private AbilityConfig _abilityConfigs;
        private Dictionary<string, Ability> _abilities;
        
        public void Init(AbilityData[] abilityConfigs)
        {
            //_abilityConfigs = abilityConfigs;
        }
        
        /*public void Init()
        {
            _abilities = new List<Ability>();
            
            foreach (var config in _abilityConfigs)
            {
                var builder = config.GetBuilder();
                
                builder.Make();
                _abilities.Add(builder.GetResult());
            }
        }*/

        public Ability GetAbility(string key) => _abilities[key];
    }
}