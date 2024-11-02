using System;
using System.Collections.Generic;
using Data;
using QFSW.QC;
using Services.Factory;
using UnityEngine;

namespace _TestViaQFSW
{
    public class ExampleHeroFactory : MonoBehaviour
    {
        [Header("Horde")]
        [SerializeField] private Hero _orc;
        [SerializeField] private Hero _troll;
        
        [Space, Header("Alliance")]
        [SerializeField] private Hero _human;
        [SerializeField] private Hero _elf;

        [Space, Header("Classes")] 
        [SerializeField] private ClassUnitData _hunter;
        [SerializeField] private ClassUnitData _druid;
        [SerializeField] private ClassUnitData _paladin;
        [SerializeField] private ClassUnitData _shaman;
        [SerializeField] private ClassUnitData _rogue;
        [SerializeField] private ClassUnitData _mage;
        [SerializeField] private ClassUnitData _warrior;
        [SerializeField] private ClassUnitData _priest;

        private readonly HeroEntityFactory _entityFactory = new HeroEntityFactory();

        private void Start()
        {
            _entityFactory.CreateEntity(_druid, _orc.raceUnitData, _orc.modelData);// todo тут почемуто нету ссылки на объект
            
            var unit = _entityFactory.GetGameObject();
            unit.GetComponent<SpriteRenderer>().color = new Color(255, 128, 0);
        }

        [Command()]
        private void create_hero(Race raceType, Class classType)
        {
            switch (raceType)
            {
                case Race.Orc:
                    _entityFactory.CreateEntity(CreateHero(classType), _orc.raceUnitData, _orc.modelData);
                    break;
                
                case Race.Troll:
                    _entityFactory.CreateEntity(CreateHero(classType), _troll.raceUnitData, _troll.modelData);
                    break;
                
                case Race.Human:
                    _entityFactory.CreateEntity(CreateHero(classType), _human.raceUnitData, _human.modelData);
                    break;
                
                case Race.Elf:
                    _entityFactory.CreateEntity(CreateHero(classType), _elf.raceUnitData, _elf.modelData);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(raceType), raceType, null);
            }
        }

        [Command()]
        private void test_init_so()
        {
            Debug.Log(_druid.Attributes.agility);
            Debug.Log(_orc.modelData.Prefab.name);
            Debug.Log(_orc.raceUnitData.Resources.health);
        }

        private ClassUnitData CreateHero(Class classType)
        {
            return classType switch
            {
                Class.Hunter => _hunter,
                Class.Druid => _druid,
                Class.Paladin => _paladin,
                Class.Shaman => _shaman,
                Class.Rogue => _rogue,
                Class.Mage => _mage,
                Class.Warrior => _warrior,
                Class.Priest => _priest,
                _ => throw new ArgumentOutOfRangeException(nameof(classType), classType, null)
            };
        }
    }

    public enum Race
    {
        Orc,
        Troll,
        Human,
        Elf
    }

    public enum Class
    {
        Hunter,
        Druid,
        Paladin,
        Shaman,
        Rogue,
        Mage,
        Warrior,
        Priest
    }

    [Serializable]
    public class Hero
    {
        public RaceUnitData raceUnitData;
        public ModelData modelData;
    }
}