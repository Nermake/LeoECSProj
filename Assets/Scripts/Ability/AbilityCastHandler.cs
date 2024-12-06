using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    public class AbilityCastHandler : MonoBehaviour
    {
        /*[SerializeField] private AbilityStorage _abilityStorage;
        [SerializeField] private Unit _unit;
        [SerializeField] private LayerMask _targetsLayer;
        
        private List<Ability> _abilities;
        private Ability _currentAbility;

        public void Init()
        {
            _abilities = new List<Ability>();
            
            _abilityStorage.Init();
            _abilities.AddRange(_abilityStorage.GetAbilities());
        }

        public void OnClickAbilityButton(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_abilities[abilityIndex].Status)
            {
                case AbilityStatus.None:
                    break;
                case AbilityStatus.Ready:
                    _currentAbility = _abilities[abilityIndex];
                    _currentAbility.StartCast();
                    break;
                case AbilityStatus.Cooldown:
                    break;
                case AbilityStatus.NeedResource:
                    break;
            }
        }

        private void Update()
        {
            foreach (var ability in _abilities)
            {
                ability.EventTick(Time.deltaTime);
            }

            if (_currentAbility != null)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    _currentAbility.CancelCast();
                    _currentAbility = null;
                }
            }
        }*/
    }
}