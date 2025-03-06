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

        public void SetFillAmount(float value) => _image.fillAmount = value;
        public void SetCurrent(float value) => _current.text = $"{value:f0}";
        public void SetRegeneration(float value) => _regeneration.text = $"{value}";
        public void SetColor(Color color) => _image.color = color;
    }
}