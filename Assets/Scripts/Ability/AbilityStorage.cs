using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private AbilityConfig[] _abilityConfigs;

        private List<Ability> _abilities;

        public void Init()
        {
            _abilities = new List<Ability>();
            
            foreach (var config in _abilityConfigs)
            {
                var builder = config.GetBuilder();
                
                builder.Make();
                _abilities.Add(builder.GetResult());
            }
        }

        public Ability[] GetAbilities() => _abilities.ToArray();
    }
}