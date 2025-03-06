using System.Collections.Generic;
using Services.Locator;
using UnityEngine;
using View;

namespace ECS.Data
{
    public class SceneData : MonoBehaviour, IService
    {
        [field: Header("Camera")]
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public float Smoothing { get; private set; }
        
        [field: Space, Header("Other References")]
        [field: SerializeField] public List<Transform> SpawnPoints { get; private set; }
        [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
        [field: SerializeField] public GameObject EnemyPrefab { get; private set; }
        
        [field: Space, Header("Test")]
        [field: SerializeField] public MainFrameView MainFrameView { get; private set; }
        [field: SerializeField] public AbilityCastView AbilityCastView { get; private set; }
        [field: SerializeField] public GoldPanelView GoldPanelView { get; private set; }
    }
}