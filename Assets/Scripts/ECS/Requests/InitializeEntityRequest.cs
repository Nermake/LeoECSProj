using System;

namespace ECS.Requests
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference entityReference;
    }
}