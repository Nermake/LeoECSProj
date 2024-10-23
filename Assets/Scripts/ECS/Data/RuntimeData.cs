using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Data
{
    public class RuntimeData
    {
        public readonly BuilderData BuilderData = new BuilderData();
        
        public GameObject Player;
        public EcsEntity PlayerEntity = EcsEntity.Null;
    }
}