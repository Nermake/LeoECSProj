using System.Collections.Generic;
using Game.Types;

namespace ECS.Components
{
    public struct DamageableComponent
    {
        public Queue<Damage> DamageQueue;
    }
}