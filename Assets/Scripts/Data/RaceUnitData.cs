using ECS.Components;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RaceUnitData", menuName = "Game Data/ECS/Race Unit Data", order = 0)]
    public class RaceUnitData : ScriptableObject
    {
        [SerializeField] private AttributesUnitComponent _attributes;

        public AttributesUnitComponent Attributes => _attributes;
    }
}