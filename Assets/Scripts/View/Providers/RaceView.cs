using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class RaceView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetSprite(Sprite sprite) => _image.sprite = sprite;
    }
}