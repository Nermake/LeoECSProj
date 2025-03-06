using UnityEngine;
using View;

namespace Services.Factory
{
    public interface IViewFactory
    {
        public AbilityView CreateAbilityView(AbilityView view, Transform parent);
    }
}