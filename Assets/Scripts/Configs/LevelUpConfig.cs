using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "Game/Level Up Config", order = 0)]
    public class LevelUpConfig : ScriptableObject
    {
        [field: SerializeField] public List<float> Limit { get; private set; }
    }
}