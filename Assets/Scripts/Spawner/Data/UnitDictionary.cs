using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawner
{
    [CreateAssetMenu(fileName = "UnitDictionary", menuName = "Game Data/UnitData Dictionary/Dictionary", order = 0)]
    public class UnitDictionary : ScriptableObject
    {
        [SerializeField] private List<UnitData> _units;
        
        public Dictionary<UnitType, GameObject> Units => CreateDictionary();
        
        private Dictionary<UnitType, GameObject> CreateDictionary()
        {
            return _units.ToDictionary(unit => unit.Type, unit => unit.Prefabs);
        }
    }
}