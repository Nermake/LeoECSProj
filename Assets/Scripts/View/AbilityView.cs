using TMPro;
using UnityEngine;

namespace View
{
    public class AbilityView : MonoBehaviour, IApply
    {
        [SerializeField] private Sprite _AbilityIcon;
        [SerializeField] private Sprite _cooldownIcon;
        [SerializeField] private Sprite _readinessIcon;
        [SerializeField] private TMP_Text _cooldownTimer;
        
        public void Apply()
        {
            
        }
    }
}