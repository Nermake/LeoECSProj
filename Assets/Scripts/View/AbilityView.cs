using ECS.Events;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace View
{
    public class AbilityView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _abilityImage;
        [SerializeField] private Image _cooldownImage;
        [SerializeField] private Image _readinessImage;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _cooldownTimer;
        [SerializeField] private TMP_Text _resourceCost;
        [SerializeField] private TMP_Text _keyCode;

        private EcsEntity _abilityOwner;
        private EcsEntity _ability;

        public void Init(EcsEntity ability, EcsEntity abilityOwner)
        {
            _ability = ability;
            _abilityOwner = abilityOwner;
        }
        
        public void Apply()
        {
            _ability.Get<AbilityApplyStartEvent>();
        }

        public void SetAbility(EcsEntity ability) => _ability = ability;
        public void SetAbilityImage(Sprite sprite) => _abilityImage.sprite = sprite;
        public void SetCooldownFillAmount(float value) => _cooldownImage.fillAmount = value;
        public void SetReadiness(bool value) => _readinessImage.enabled = !value;
        public void SetLevel(sbyte value) => _level.text = $"Lvl. {value}";
        public void SetCooldownTimer(string time) => _cooldownTimer.text = time;
        public void SetResourceCost(int value) => _resourceCost.text = $"{value}";
        public void SetResourceColor(Color color) => _resourceCost.color = color;
        public void SetKeyCode(string key) => _keyCode.text = key;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_abilityOwner != EcsEntity.Null) _abilityOwner.Get<AbilityOnPointerEnterEvent>();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_abilityOwner != EcsEntity.Null) _abilityOwner.Get<AbilityOnPointerExitEvent>();
        }
    }
}