using GameTypes;
using UnityEngine;

namespace Spawner
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Game Data/Unit Data Dictionary/Unit Data", order = 0)]
    public class UnitData : ScriptableObject
    {
        [SerializeField] private UnitType _type;
        [SerializeField] private GameObject _prefabs;

        public UnitType Type => _type;
        public GameObject Prefabs => _prefabs;
    }
}