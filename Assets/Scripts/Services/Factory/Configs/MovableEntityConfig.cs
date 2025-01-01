using UnityEngine;

namespace Services.Factory
{
    public class MovableEntityConfig : EntityConfig
    {
        [field: Header("UnitMovable")]
        [field: SerializeField] public float Speed { get; private set; }
        
        public override EntityBuilder GetBuilder()
        {
            return new MovableEntityBuilder(this);
        }
    }
}