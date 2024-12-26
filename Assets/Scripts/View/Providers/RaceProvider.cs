using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    [Serializable]
    public class RaceProvider
    {
        [field: SerializeField] public Image Image { get; private set; }
    }
}