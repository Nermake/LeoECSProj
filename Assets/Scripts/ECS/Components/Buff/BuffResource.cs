using Game.Types;

namespace ECS.Components
{
    public struct BuffResource
    {
        public UnitResourcesType Type;
        
        public float Pool;
        public float Regeneration;
        public float Reduction;
    }
}