using System;
using System.Collections.Generic;
using Game.Types;

namespace ECS.Components
{
    [Serializable]
    public struct DamageableComponent
    {
        public Queue<Damage> damageQueue;
    }
}