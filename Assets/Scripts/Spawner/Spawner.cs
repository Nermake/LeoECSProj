using Factory;
using GameTypes;
using UnityEngine;

namespace Spawner
{
    public class Spawner : ISpawner
    {
        private AbstractEntityFactory _entityFactory;

        public void Init()
        {
            _entityFactory = new EntityFactory();
        }


        public void Spawn<T>(UnitType key) where T : AbstractEntityFactory
        {
            
        }

        public void SpawnAtPoint<T>(UnitType key, Vector2 pos) where T : AbstractEntityFactory
        {
            
        }
    }
}