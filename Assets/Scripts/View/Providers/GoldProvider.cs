using System;
using TMPro;
using UnityEngine;

namespace View
{
    [Serializable]
    public class GoldProvider
    {
        [field: SerializeField] public TMP_Text Counter { get; private set; }
    }
}