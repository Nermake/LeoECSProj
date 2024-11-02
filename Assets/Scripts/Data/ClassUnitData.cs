using ECS.Components;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ClassUnitData", menuName = "Game Data/ECS/Class Unit Data", order = 0)]
    public class ClassUnitData : ScriptableObject
    {
        [SerializeField] private AttributesUnitComponent _attributes;

        public AttributesUnitComponent Attributes => _attributes;
    }
}