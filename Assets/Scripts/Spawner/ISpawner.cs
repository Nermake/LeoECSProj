using Factory;
using GameTypes;
using UnityEngine;

namespace Spawner
{
    public interface ISpawner
    {
        void Spawn<T>(UnitType key) where T : AbstractEntityFactory;
        void SpawnAtPoint<T>(UnitType key, Vector2 pos) where T : AbstractEntityFactory;
    }
}