using UnityEngine;

namespace Services.ObjectPool
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand = false;
        [SerializeField] private Unit _unit;

        private PoolMono<Unit> _pool;

        private void Start()
        {
            _pool = new PoolMono<Unit>(_unit, _poolCount, _autoExpand);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) CreateCube();
        }

        private void CreateCube()
        {
            var rX = Random.Range(-5f, 5f);
            var rZ = Random.Range(-5f, 5f);
            var y = 0;
            
            var rPosition = new Vector3(rX, y, rZ);
            var cube = _pool.GetFreeElement();
            cube.transform.position = rPosition;
        }
    }
}