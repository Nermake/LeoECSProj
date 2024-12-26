using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    [Serializable]
    public class LevelProvider
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public TMP_Text Counter { get; private set; }
    }
}