using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Ability
{
    public class Ability
    {
        public event Action<float, float> EventChangeCooldownTimer;

        protected string _id;
        protected string _title;
        protected string _description;
        protected Sprite _icon;
        protected float _cooldown;
        protected float _cooldownTimer;
        protected float _resourceCost;
        protected EcsEntity _entity;
        protected ResourceCostType _resourceType;
        protected AbilityStatus _status;

        public void SetID(string id) => _id = id;
        
        public void SetDescription(string title, string description, Sprite icon)
        {
            _title = title;
            _description = description;
            _icon = icon;
        }
        
        public void SetResource(float cost, ResourceCostType type)
        {
            _resourceCost = cost;
            _resourceType = type;
        }
        
        public void SetCooldown(float cooldown) => _cooldown = cooldown;
        public void ChangeStatus(AbilityStatus status) => _status = status;
        
        public virtual void ApplyCast() { }
    }
}