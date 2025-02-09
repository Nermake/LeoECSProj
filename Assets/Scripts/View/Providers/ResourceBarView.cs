using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ResourceBarView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _current;
        [SerializeField] private TMP_Text _regeneration;

        public void SetPercent(float value) => _image.fillAmount = value;
        public void SetCurrentHealth(float value) => _current.text = $"{value}";
        public void SetRegeneration(float value) => _regeneration.text = $"{value}";
    }
}