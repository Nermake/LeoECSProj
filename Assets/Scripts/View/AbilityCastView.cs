using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class AbilityCastView : MonoBehaviour
    {
        [SerializeField] private Image _abilityImage;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TMP_Text _abilityText;
        [SerializeField] private TMP_Text _timerText;

        public void ShowAbilityText()
        {
            _abilityText.gameObject.SetActive(true);
        }

        public void HideAbilityText()
        {
            _abilityText.gameObject.SetActive(false);
        }

        public void ShowTimerText()
        {
            _timerText.gameObject.SetActive(true);
        }

        public void HideTimerText()
        {
            _timerText.gameObject.SetActive(false);
        }
        
        public void SetImage(Sprite sprite) => _abilityImage.sprite = sprite;
        public void SetFillAmount(float progress) => _progressImage.fillAmount = progress;
        public void SetAbilityText(string text) => _abilityText.text = text;
        public void SetTimerText(string text) => _timerText.text = text;
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}