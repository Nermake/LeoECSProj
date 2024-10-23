using ECS;
using UnityEngine;

namespace Data.Configs
{
    [CreateAssetMenu(fileName = "EntityConfig", menuName = "Game Data/ECS/Entity Config", order = 0)]
    public class EntityConfig : ScriptableObject
    {
        [field: SerializeField] public EntityReference player { get; private set; }
        [field: SerializeField] public EntityReference enemyMile { get; private set; }
        [field: SerializeField] public EntityReference enemyRange { get; private set; }
        [field: SerializeField] public EntityReference projectile { get; private set; }
        [field: SerializeField] public EntityReference entity { get; private set; }
        
    }
}