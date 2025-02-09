using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ResourcePlateView : MonoBehaviour
    {
        [field: SerializeField] public Image Health { get; private set; }
        [field: SerializeField] public Image SecondaryResource { get; private set; }
    }
}