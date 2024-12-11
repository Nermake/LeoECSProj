using System;
using Game.Types;
using Logic.View;

namespace ECS.Components
{
    [Serializable]
    public struct ResourceViewComponent
    {
        public ResourcePanelView resourcePanelView;
        public UnitResourcesType secondaryResourcesType;
    }
}