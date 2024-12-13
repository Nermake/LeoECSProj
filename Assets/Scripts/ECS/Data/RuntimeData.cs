using Leopotam.Ecs;
using Logic.View;
using Services.Locator;
using UnityEngine;

namespace ECS.Data
{
    public class RuntimeData : IService
    {
        public readonly BuilderData BuilderData = new();
        
        public ActorView PlayerActor;
    }
}