using System.Collections.Generic;
using UnityEngine;

namespace GameTypes
{
    [CreateAssetMenu(fileName = "Test UnitConfig", menuName = "Game Data/Test/Test UnitConfig", order = 0)]
    public class UnitConfig : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _health;
        [SerializeField] private float _mana;
        [SerializeField] private float _energy;
        [SerializeField] private float _rage;
        [SerializeField] private float _armor;
        [SerializeField] private float _fireResist;
        [SerializeField] private float _frostResist;
        [SerializeField] private float _shadowResist;
        [SerializeField] private float _lightResist;
        [SerializeField] private float _arcaneResist;
        [SerializeField] private float _natureResist;

        #endregion
        
        private Dictionary<EffectType, float> _resists;
        private Dictionary<UnitResourceType, float> _unitResource;

        public void Init()
        {
            CreateResistDictionary();
            CreateUnitResourceDictionary();
        }
        
        public Dictionary<EffectType, float> GetResists()  => _resists;
        public Dictionary<UnitResourceType, float> GetUnitResource()  => _unitResource;
        public float GetUnitResource(UnitResourceType type) => _unitResource[type];
        
        
        
        private void CreateResistDictionary()
        {
            _resists = new Dictionary<EffectType, float>
            {
                {EffectType.Physical, _armor},
                {EffectType.Fire, _fireResist},
                {EffectType.Frost, _frostResist},
                {EffectType.Shadow, _shadowResist},
                {EffectType.Light, _lightResist},
                {EffectType.Arcane, _arcaneResist},
                {EffectType.Nature, _natureResist}
            };
        }
        
        private void CreateUnitResourceDictionary()
        {
            _unitResource = new Dictionary<UnitResourceType, float>
            {
                {UnitResourceType.Health, _health},
                {UnitResourceType.Mana, _mana},
                {UnitResourceType.Energy, _energy},
                {UnitResourceType.Rage, _rage}
            };
        }
    }
}