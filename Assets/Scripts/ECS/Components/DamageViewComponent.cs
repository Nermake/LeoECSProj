using Logic.View;
using UnityEngine;

namespace ECS.Components
{
    public struct DamageViewComponent
    {
        public Vector2 healthWidgetOffset;
        public EntityView view;
    }
}