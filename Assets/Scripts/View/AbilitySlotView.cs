using UnityEngine;

namespace View
{
    public class AbilitySlotView : MonoBehaviour
    {
        private AbilityView _abilityView;
        
        public void SetAbility(AbilityView ability)
        {
            _abilityView = ability;
        }

        public void ApplyCast() // todo test factor
        {
            _abilityView.Apply();
        }

        public void CancelCast()
        {
            
        }
    }
}