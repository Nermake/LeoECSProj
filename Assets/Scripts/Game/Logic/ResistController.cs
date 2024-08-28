using System;
using System.Collections.Generic;
using GameTypes;

namespace Game.Logic
{
    public class ResistController : IController
    {
        public event Action<EffectType, float> ResistChanged;
        
        private float _armor;
        private float _fireResist;
        private float _frostResist;
        private float _shadowResist;
        private float _lightResist;
        private float _arcaneResist;
        private float _natureResist;
        
        private EffectType _type;
        
        private Dictionary<EffectType, float> _resists;

        public ResistController(Dictionary<EffectType, float> resists)
        {
            _resists = resists;
        }
        
        public void Init()
        {
            _resists = new Dictionary<EffectType, float>();
            
            FillDictionary();
        }

        private void FillDictionary()
        {
            _resists.Add(EffectType.Physical, _armor);
            _resists.Add(EffectType.Fire, _fireResist);
            _resists.Add(EffectType.Frost, _frostResist);
            _resists.Add(EffectType.Shadow, _shadowResist);
            _resists.Add(EffectType.Light, _lightResist);
            _resists.Add(EffectType.Arcane, _arcaneResist);
            _resists.Add(EffectType.Nature, _natureResist);
        }

        public void AddResist(EffectType key, float change)
        {
            _resists[key] += change;
            ResistChanged?.Invoke(key, _resists[key]);
        }
        
        public void RemoveResist(EffectType key, float change)
        {
            _resists[key] -= change;
            ResistChanged?.Invoke(key, _resists[key]);
        }

        public ResistController GetController() => this;
    }
}