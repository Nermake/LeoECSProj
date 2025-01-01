using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    [Serializable]
    public class ResourceProvider
    {
        [field: SerializeField] public ResourceBar Health { get; private set; }
        [field: SerializeField] public ResourceBar SecondaryResource { get; private set; }
    }

    [Serializable]
    public class ResourceBar
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public TMP_Text CurrentHealth { get; private set; }
        [field: SerializeField] public TMP_Text Regeneration { get; private set; }
    }
}