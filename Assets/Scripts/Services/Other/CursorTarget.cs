using ECS.Data;
using Logic.View;
using UnityEngine;
using Zenject;

namespace Services
{
    public class CursorTarget : ITickable
    {
        private Camera _camera;
        private Ray _ray;

        public RaycastHit Hit { get; private set; }
        
        public CursorTarget(SceneData sceneData)
        {
            _camera = sceneData.Camera;
        }
        
        public void Tick()
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