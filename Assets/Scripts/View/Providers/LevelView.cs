using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] public TMP_Text _counter;

        public void SetFillAmount(float value) => _image.fillAmount = value;
        public void SetLevel(int value) => _counter.text = $"{value}";
    }
}