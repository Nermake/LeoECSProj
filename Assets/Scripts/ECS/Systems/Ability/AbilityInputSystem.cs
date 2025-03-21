using System.Collections.Generic;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine.InputSystem;
using View;
using Zenject;

namespace ECS.Systems
{
    public sealed class AbilityInputSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<AbilityRunCastEvent> _filter;
        
        private readonly List<AbilityView> _abilityViews;
        private readonly InputController _inputController;

        public AbilityInputSystem(DiContainer container)
        {
            _abilityViews = container.Resolve<SceneData>().MainFrameView.AbilityPanelView.GetAbilityViews();
            _inputController = container.Resolve<InputController>();
        }
        
        public void Init()
        {
            _inputController.Game.Ability1.started += OnApplyAbility1;
            _inputController.Game.Ability2.started += OnApplyAbility2;
            _inputController.Game.Ability3.started += OnApplyAbility3;
            _inputController.Game.Ability4.started += OnApplyAbility4;
            _inputController.Game.Ability5.started += OnApplyAbility5;
            _inputController.Game.Ability6.started += OnApplyAbility6;
            
            _inputController.Game.Escape.started += OnEscape;
        }
        
        private void OnApplyAbility1(InputAction.CallbackContext obj) => _abilityViews[0].Apply();
        private void OnApplyAbility2(InputAction.CallbackContext obj) => _abilityViews[1].Apply();
        private void OnApplyAbility3(InputAction.CallbackContext obj) => _abilityViews[2].Apply();
        private void OnApplyAbility4(InputAction.CallbackContext obj) => _abilityViews[3].Apply();
        private void OnApplyAbility5(InputAction.CallbackContext obj) => _abilityViews[4].Apply();
        private void OnApplyAbility6(InputAction.CallbackContext obj) => _abilityViews[5].Apply();

        private void OnEscape(InputAction.CallbackContext obj)
        {
            foreach (var i in _filter)
            {
                _filter.GetEntity(i).Get<AbilityCancelCastEvent>();
            }
        }
        
        public void Destroy()
        {
            _inputController.Game.Ability1.started -= OnApplyAbility1;
            _inputController.Game.Ability2.started -= OnApplyAbility2;
            _inputController.Game.Ability3.started -= OnApplyAbility3;
            _inputController.Game.Ability4.started -= OnApplyAbility4;
            _inputController.Game.Ability5.started -= OnApplyAbility5;
            _inputController.Game.Ability6.started -= OnApplyAbility6;
            
            _inputController.Game.Escape.started -= OnEscape;
        }
    }
}