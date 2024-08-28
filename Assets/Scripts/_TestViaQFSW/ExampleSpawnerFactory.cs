using Builder;
using Factory;
using QFSW.QC;
using UnityEngine;

namespace _TestViaQFSW
{
    public class ExampleSpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        
        private AbstractEntitySpawnerFactory _abstractEntitySpawnerFactory;
        private UnitBuilder _builder;

        private void Start()
        {
            _abstractEntitySpawnerFactory = new EntitySpawnerFactory();
            _builder = new UnitBuilder();
        }
        
        [Command("spawn_entity")]
        private void SpawnEntity()
        {
            _abstractEntitySpawnerFactory.CreateEntity(_builder, _prefab);
        }
    }
}