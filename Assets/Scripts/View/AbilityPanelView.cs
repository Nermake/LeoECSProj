using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class AbilityPanelView : MonoBehaviour
    {
        [SerializeField] private List<AbilityView> _abilityViews;
        
        public List<AbilityView> GetAbilityViews() => _abilityViews;
    }
}