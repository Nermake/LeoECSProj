using System;
using System.Collections.Generic;
using ECS.Components;
using Game.Types;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "RaceConfig", menuName = "Game/Race Config", order = 0)]
    public class RaceConfig : ScriptableObject
    {
        [field: SerializeField] public List<RaceData> RaceDats { get; private set; }
    }

    [Serializable]
    public class RaceData
    {
        [field: SerializeField] public RaceType Race { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public AttributesUnitComponent Attributes { get; private set; }
    }
}