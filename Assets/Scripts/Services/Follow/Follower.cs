using UnityEngine;

namespace Follow
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothing;
    
        protected void Follow(float deltaTime)
        {
            var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _smoothing * deltaTime);
    
            transform.position = nextPosition;
        }
    }
}
