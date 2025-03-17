using ECS.Data;
using Logic.View;
using Services.Locator;
using UnityEngine;

namespace Services
{
    public class CursorTarget : MonoBehaviour, IService
    {
        private Camera _camera;
        private Ray _ray;
        
        public RaycastHit Hit { get; private set; }

        private void Start()
        {
            _camera = ServiceLocator.Current.Get<SceneData>().Camera;
        }

        private void Update()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            Hit = Physics.Raycast(_ray, out var raycastHit)
                ? raycastHit
                : new RaycastHit();
        }

        public bool TryGetView<T>(out T entityView) where T : EntityView
        {
            if (Hit.collider != null && Hit.collider.TryGetComponent(out entityView))
            {
                return true;
            }

            entityView = null;
            return false;
        }
    }
}