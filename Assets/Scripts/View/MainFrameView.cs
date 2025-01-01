using UnityEngine;

namespace View
{
    public class MainFrameView : MonoBehaviour
    {
        [field: SerializeField] public RaceProvider RaceProvider { get; private set; }
        [field: SerializeField] public LevelProvider LevelProvider { get; private set; }
        [field: SerializeField] public ResourceProvider ResourceProvider { get; private set; }
    }
}