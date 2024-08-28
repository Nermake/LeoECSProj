using System;
using System.Collections.Generic;
using GameTypes;
using UnityEngine;

namespace Ability
{
    public class AbilityCastHandler : MonoBehaviour
    {
        [SerializeField] private AbilityStorage _abilityStorage;
        [SerializeField] private Unit _unit;
        [SerializeField] private LayerMask _targetsLayer;
        
        private List<Ability> _abilities;
        private Ability _currentAbility;
        private Camera _camera;

        public void Init()
        {
            _abilities = new List<Ability>();
            _camera = Camera.main;
            
            _abilityStorage.Init();
            _abilities.AddRange(_abilityStorage.GetAbilities());
        }

        public void OnClickAbilityButton(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_abilities[abilityIndex].Status)
            {
                case EAbilityStatus.None:
                    break;
                case EAbilityStatus.Ready:
                    _currentAbility = _abilities[abilityIndex];
                    _currentAbility.StartCast();
                    break;
                case EAbilityStatus.Cooldown:
                    break;
                case EAbilityStatus.NeedResource:
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
        }
    }
}