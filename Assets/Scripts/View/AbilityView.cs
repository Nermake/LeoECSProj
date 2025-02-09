using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class AbilityView : MonoBehaviour, IApply
    {
        [SerializeField] private Image _abilityImage;
        [SerializeField] private Image _cooldownImage;
        [SerializeField] private Image _readinessImage;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _cooldownTimer;

        private EcsEntity _entity;

        public void SetEntity(EcsEntity entity) => _entity = entity;
        
        public void Apply()
        {
            
        }

        public void SetAbilityImage(Sprite sprite) => _abilityImage.sprite = sprite;
        public void SetCooldownImage(float value) => _cooldownImage.fillAmount = value;
        public void SetReadiness(Sprite sprite) => _readinessImage.sprite = sprite;
        public void SetLevel(sbyte value) => _level.text = $"Lvl. {value.ToString()}";
        public void SetCooldownTimer(int value, string liter) => _cooldownTimer.text = $"{value.ToString()}{liter}.";
    }
}