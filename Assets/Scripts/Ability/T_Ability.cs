using System;
using GameTypes;
using UnityEngine;

namespace Ability
{
    public abstract class T_Ability
    {
        public event Action<float, float> EventChangeCooldownTimer;
        
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Sprite DisplayImage { get; private set; }
        
        public float CooldownTime { get; private set; }
        public float CooldownTimer { get; private set; }
        public float CastTime { get; private set; }

        public float ResourceCost { get; private set; }
        public EResourceCostType ResourceType { get; private set; }
        
        public EAbilityType AbilityType { get; private set; }
        public EAbilityOgType AbilityOgType { get; private set; }
        public EBuffDebuffType BuffDebuffType { get; private set; }
        public EAbilityVectorType AbilityVectorType { get; private set; }
        
        public EAbilityStatus Status { get; private set; }
        
        public KeyCode HotKey { get; private set; }
        
        public void SetDescription(string title, string description, Sprite displayImage)
        {
            Title = title;
            Description = description;
            DisplayImage = displayImage;
        }

        public void SetResourceCost(float cost, EResourceCostType type)
        {
            ResourceCost = cost;
            ResourceType = type;
        }

        public void SetKey(KeyCode key) => HotKey = key;
        public void SetCooldown(float cooldown) => CooldownTime = cooldown;
        public void ChangeStatus(EAbilityStatus status) => Status = status;

        public void ChangeCooldownTimer(float timer)
        {
            CooldownTimer = Mathf.Clamp(timer, 0.0f, CooldownTime);
            EventChangeCooldownTimer?.Invoke(CooldownTimer, CooldownTime);
        }

        public virtual void StartCast() { }

        public virtual bool CheckCondition(Unit owner, Unit target, Vector2 location = default)
        {
            return false;
        }

        public virtual void ApplyCast() { }
        public virtual void EventTick(float deltaTick) { }
        public virtual void CancelCast() { }
    }

    public enum EAbilityType : sbyte
    {
        None,
        Buff,
        Debuff,
        Both
    }
    
    public enum EAbilityVectorType : sbyte
    {
        NoneTarget,
        Target,
        Oblast, 
        Kon
    }
    
    public enum EBuffDebuffType : sbyte
    {
        None,
        Physical,
        Magic,
        Curse,
        Venom,
        Boles
    }
    
    public enum EAbilityOgType : sbyte
    {
        None,
        Silence,
        Bush,
        Hex
    }
}