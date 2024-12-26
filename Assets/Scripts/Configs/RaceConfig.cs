using System;
using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "RaceConfig", menuName = "Game/Race Config", order = 0)]
    public class RaceConfig : ScriptableObject
    {
        [field: SerializeField] public List<RaceData> Races { get; private set; }
    }

    [Serializable]
    public class RaceData
    {
        [field: SerializeField] public RaceType Race { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}