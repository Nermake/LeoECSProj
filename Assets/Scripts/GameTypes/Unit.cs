using System;
using System.Collections.Generic;
using Game.Logic;
using UnityEngine;

namespace GameTypes
{
    public class Unit : MonoBehaviour, IUnit
    {
        private UnitConfig _config;
        private StatsController _statsController;
        private readonly Dictionary<Type, IController> _controllers;

        public void Init()
        {
            _config.Init();
            
            _statsController = new StatsController(_config, this);
            _statsController.Init();
        }

        public T GetController<T>() where T : IController
        {
            var type = typeof(T);
    
            if (_controllers.TryGetValue(type, out var controller))
            {
                return (T)controller;
            }
    
            throw new KeyNotFoundException($"Type controller {type.Name} not found.");
        }

        private void AddControllers()
        {
            //_controllers.Add(typeof(HealthController), );
        }
    }
}