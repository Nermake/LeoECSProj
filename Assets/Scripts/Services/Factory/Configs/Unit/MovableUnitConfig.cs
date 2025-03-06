using UnityEngine;

namespace Services.Factory
{
    public class MovableUnitConfig : UnitConfig
    {
        [field: Header("UnitMovable")]
        [field: SerializeField] public float Speed { get; private set; }
        
        public override UnitBuilder GetBuilder()
        {
            return new MovableUnitBuilder(this);
        }
    }
}