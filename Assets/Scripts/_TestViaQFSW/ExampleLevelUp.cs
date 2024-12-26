using System;
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

        private void Start()
        {
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }

        [Command]
        private void lvlup_add()
        {
            _runtimeData.PlayerActor.GetEntity().Get<AddExperienceEvent>().Amount += 5;
        }

        [Command]
        private void race_change(RaceType type)
        {
            _runtimeData.PlayerActor.GetEntity().Get<ChangeRaceEvent>().NewRace = type;
        }

        [Command]
        private void gold_change(CommandType type, int amount)
        {
            switch (type)
            {
                case CommandType.Add:
                    break;
                case CommandType.Remove:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public enum CommandType
        {
            Add,
            Remove
        }
    }
}