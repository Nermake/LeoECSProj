using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ModelData", menuName = "Game Data/ECS/Model Data", order = 0)]
    public class ModelData : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}