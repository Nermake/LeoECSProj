using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Game Data/Ability/Config", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public List<Ability> Abilities { get; private set; }
    }
}