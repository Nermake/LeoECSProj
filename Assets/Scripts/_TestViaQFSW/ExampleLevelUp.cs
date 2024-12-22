using System;
using ECS.Components;
using ECS.Data;
using ECS.Events;
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
    }
}