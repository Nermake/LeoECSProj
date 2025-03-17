using UnityEngine;

namespace Services.Factory
{
    public abstract class MovableUnitConfig : UnitConfig
    {
        [field: Header("UnitMovable")]
        [field: SerializeField] public float Speed { get; private set; }
        
        public override UnitBuilder GetBuilder()
        {
            return new MovableUnitBuilder(this);
        }
    }
}