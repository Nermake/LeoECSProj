using UnityEngine;

namespace View
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}