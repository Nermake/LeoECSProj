using UnityEngine;

namespace View
{
    public class MainFrameView : MonoBehaviour
    {
        [field: SerializeField] public RaceView RaceView { get; private set; }
        [field: SerializeField] public LevelView LevelView { get; private set; }
        [field: SerializeField] public ResourceBarView HealthBarView { get; private set; }
        [field: SerializeField] public ResourceBarView SecondaryResourceBarView { get; private set; }
        [field: SerializeField] public AbilityPanelView AbilityPanelView { get; private set; }
    }
}