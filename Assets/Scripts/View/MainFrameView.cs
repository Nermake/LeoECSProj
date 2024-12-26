using UnityEngine;

namespace View
{
    public class MainFrameView : MonoBehaviour
    {
        [field: SerializeField] public RaceProvider RaceProvider { get; set; }
        [field: SerializeField] public LevelProvider LevelProvider { get; set; }
    }
}