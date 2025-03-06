using System;
using ECS.Data;
using Game.Types;
using Leopotam.Ecs;
using QFSW.QC;
using Services.Factory;
using Services.Locator;
using StaticString;
using UnityEngine;
using UnityEngine.Serialization;
using View;

namespace _TestViaQFSW
{
    public class ExampleAbility : MonoBehaviour
    {
        [Header("1")]
        [SerializeField] private AbilityView _view1;
        [SerializeField] private AbilityConfig _config1;
        [Header("2")]
        [SerializeField] private AbilityView _view2;
        [SerializeField] private AbilityConfig _config2;
        [Header("3")]
        [SerializeField] private AbilityView _view3;
        [SerializeField] private AbilityConfig _config3;
        [Header("4")]
        [SerializeField] private AbilityView _view4;
        [SerializeField] private AbilityConfig _config4;
        [Header("5")]
        [SerializeField] private AbilityView _view5;
        [SerializeField] private AbilityConfig _config5;
        [Header("6")]
        [SerializeField] private AbilityView _view6;
        [SerializeField] private AbilityConfig _config6;

        private EntityFactory _entityFactory;
        private RuntimeData _runtimeData;
        
        private void Start()
        {
            _entityFactory = ServiceLocator.Current.Get<EntityFactory>();
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }

        [Command]
        private void create_ability()
        {
            Debug.Log(
                $" [ExampleAbility -> create_ability(1)]: \n{_config1}, {_runtimeData.PlayerActor.GetEntity()}, {_view1}");

            ref var ability1 =
                ref _entityFactory.CreateAbilityEntity(_config1, _runtimeData.PlayerActor.GetEntity(), _view1);

            Debug.Log($"[ExampleAbility -> create_ability(1) -> ability]: {ability1}");
            //-------//
            Debug.Log(
                $" [ExampleAbility -> create_ability(2)]: \n{_config2}, {_runtimeData.PlayerActor.GetEntity()}, {_view2}");

            ref var ability2 =
                ref _entityFactory.CreateAbilityEntity(_config2, _runtimeData.PlayerActor.GetEntity(), _view2);

            Debug.Log($"[ExampleAbility -> create_ability(2) -> ability]: {ability2}");
            //-------//
            Debug.Log(
                $" [ExampleAbility -> create_ability(3)]: \n{_config3}, {_runtimeData.PlayerActor.GetEntity()}, {_view3}");

            ref var ability3 =
                ref _entityFactory.CreateAbilityEntity(_config3, _runtimeData.PlayerActor.GetEntity(), _view3);

            Debug.Log($"[ExampleAbility -> create_ability(3) -> ability]: {ability3}");
        }
    }
}