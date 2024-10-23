using UnityEngine;

namespace Spawner
{
    public interface ISpawner
    {
        void Spawn(GameObject gameObject);
        void SpawnAtPoint(GameObject gameObject, Vector2 pos);
    }
}