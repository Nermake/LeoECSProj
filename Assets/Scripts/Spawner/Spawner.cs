using System;
using System.Collections.Generic;
using Factory;
using GameTypes;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private UnitDictionary _unitDictionary;

        private Dictionary<UnitType, GameObject> _unitPrefabs;

        private void Start()
        {
            _unitPrefabs = _unitDictionary.Units;
        }


        public void Spawn<T>(UnitType key, Vector2 pos) where T : AbstractEntitySpawnerFactory
        {
            
        }
    }
}