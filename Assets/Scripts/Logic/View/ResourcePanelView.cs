using System;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.View
{
    public class ResourcePanelView : MonoBehaviour
    {
        [field: SerializeField] public Image Health { get; private set; }
        [field: SerializeField] public Image SecondaryResource { get; private set; }
    }
}