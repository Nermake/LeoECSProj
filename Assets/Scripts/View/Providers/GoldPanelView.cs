using TMPro;
using UnityEngine;

namespace View
{
    public class GoldPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;

        public void SetGoldAmount(int value) => _counter.text = $"{value}";

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}