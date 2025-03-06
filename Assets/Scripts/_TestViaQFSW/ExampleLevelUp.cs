using System;
using Configs;
using ECS.Components;
using ECS.Data;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using QFSW.QC;
using Services.Locator;
using UnityEngine;

namespace _TestViaQFSW
{
    public class ExampleLevelUp : MonoBehaviour
    {
        private RuntimeData _runtimeData;
        private LevelUpConfig _levelUpConfig;

        private void Start()
        {
            _levelUpConfig = ServiceLocator.Current.Get<StaticData>().LevelUpConfig;
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }

        [Command]
        private void lvlup_add(EXP command, int amount = default)
        {
            switch (command)
            {
                case EXP.AddLevel:
                    ref var experienceComponent = ref _runtimeData.PlayerActor.GetEntity().Get<ExperienceComponent>();
                    experienceComponent.Level += (byte)amount;
                    experienceComponent.Current = 0;
                    experienceComponent.Limit =
                        _levelUpConfig.Limit[experienceComponent.Level - 1];
                    
                    _runtimeData.PlayerActor.GetEntity().Get<LevelUpEvent>();
                    break;
                case EXP.AddExp:
                    _runtimeData.PlayerActor.GetEntity().Get<AddExperienceEvent>().Amount += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }
        }

        [Command]
        private void race_change(RaceType type)
        {
            _runtimeData.PlayerActor.GetEntity().Get<ChangeRaceEvent>().NewRace = type;
        }

        [Command]
        private void gold_change(AC_CommandType type, int amount)
        {
            switch (type)
            {
                case AC_CommandType.Add:
                    _runtimeData.PlayerActor.GetEntity().Get<AddGoldEvent>().Amount = amount;
                    break;
                case AC_CommandType.Remove:
                    _runtimeData.PlayerActor.GetEntity().Get<RemoveGoldEvent>().Amount = amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private enum EXP
        {
            AddLevel,
            AddExp
        }
        
        private enum AC_CommandType
        {
            Add,
            Remove
        }
    }
}