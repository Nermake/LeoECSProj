using System.Collections.Generic;
using ECS;
using Services.Factory;
using UnityEngine;

namespace Spawner
{
    public class EntitySpawner //todo написать не так всрато
    {
        //private AbstractEntityFactory _entityFactory;
        private EntityConfig _entityConfig;

        private Dictionary<UnitType, EntityReference> _entityReferences;
        //private Dictionary<UnitType, BaseEntityBuilder> _builders;
        
        #region Builders

        //private EnemyMileBuilder EnemyMileBuilder;
        //private EnemyRangeBuilder _enemyRangeBuilder;
        //private PlayerEntityBuilder _playerBuilder;
        //private ProjectileEntityBuilder _projectileBuilder;

        #endregion

        public void Init(EntityConfig entityConfig)
        {
            //_entityFactory = new EntityFactory();
            _entityConfig = entityConfig;
            
            _entityReferences = new Dictionary<UnitType, EntityReference>();
            //_builders = new Dictionary<UnitType, BaseEntityBuilder>();

            InitBuilders();
            FilledDictionary();
        }

        private void InitBuilders()
        {
            //EnemyMileBuilder = new EnemyMileBuilder();
            //_enemyRangeBuilder = new EnemyRangeBuilder();
            //_playerBuilder = new PlayerEntityBuilder();
            //_projectileBuilder = new ProjectileEntityBuilder();
        }

        private void FilledDictionary()
        {
            // _entityReferences.Add(UnitType.None, null);
            // _entityReferences.Add(UnitType.Player, _entityConfig.player);
            // _entityReferences.Add(UnitType.Projectile, _entityConfig.projectile);
            // _entityReferences.Add(UnitType.EnemyMile, _entityConfig.enemyMile);
            // _entityReferences.Add(UnitType.EnemyRange, _entityConfig.enemyRange);
            
            //_builders.Add(UnitType.None, null);
            //_builders.Add(UnitType.Player, _playerBuilder);
            //_builders.Add(UnitType.Projectile, _projectileBuilder);
            //_builders.Add(UnitType.EnemyMile, EnemyMileBuilder);
            //_builders.Add(UnitType.EnemyRange, _enemyRangeBuilder);
        }

        public void Spawn(UnitType type)
        {
            if (type == UnitType.None) return;
            
            var gameObject = _entityReferences[type].gameObject;
            //var builder = _builders[type];
            
            //_entityFactory.CreateEntity(builder, gameObject);
        }
        
        public void SpawnAtPoint(UnitType type, Transform position)
        {
            if (type == UnitType.None) return;
            
            var gameObject = _entityReferences[type].gameObject;
            //var builder = _builders[type];
            
            //_entityFactory.CreateEntity(builder, gameObject, position);
        }
    }
}    