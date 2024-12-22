using System;
using Data;
using QFSW.QC;
using Services.Factory;
using UnityEngine;
using StaticString;

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
        [SerializeField] private ClassUnitData _druid;
        [SerializeField] private ClassUnitData _hunter;
        [SerializeField] private ClassUnitData _mage;
        [SerializeField] private ClassUnitData _paladin;
        [SerializeField] private ClassUnitData _priest;
        [SerializeField] private ClassUnitData _rogue;
        [SerializeField] private ClassUnitData _shaman;
        [SerializeField] private ClassUnitData _warlock;
        [SerializeField] private ClassUnitData _warrior;

        //private readonly HeroEntityFactory _entityFactory = new();
        private readonly IActorFactory _actorFactory;

        [Command()]
        private void create_hero(Race raceType, Class classType)
        {
            switch (raceType)
            {
                case Race.Orc:
                    //_entityFactory.CreateEntity(CreateHero(ClassType), _orc.raceUnitData, _orc.modelData);
                    break;
                
                case Race.Troll:
                    //_entityFactory.CreateEntity(CreateHero(ClassType), _troll.raceUnitData, _troll.modelData);
                    break;
                
                case Race.Human:
                    //_entityFactory.CreateEntity(CreateHero(ClassType), _human.raceUnitData, _human.modelData);
                    break;
                
                case Race.Elf:
                    //_entityFactory.CreateEntity(CreateHero(ClassType), _elf.raceUnitData, _elf.modelData);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(raceType), raceType, null);
            }

            //var spriteRenderer = _entityFactory.GetGameObject().GetComponent<SpriteRenderer>();
            //ChangeColor(spriteRenderer, ClassType);
        }

        [Command]
        private void create_all_class_for_orc()
        {
            ClassUnitData[] classes =
                { _druid, _hunter, _mage, _paladin, _priest, _rogue, _shaman, _warlock, _warrior };

            var i = 0;
            foreach (var variableClass in classes)
            {
                //_entityFactory.CreateEntity(variableClass, _orc.raceUnitData, _orc.modelData);
                //var spriteRenderer = _entityFactory.GetGameObject().GetComponent<SpriteRenderer>();
                //ChangeColor(spriteRenderer, i);
                i++;
            }
        }

        private static void ChangeColor(SpriteRenderer sr, Class classType)
        {
            switch (classType)
            {
                case Class.Druid: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_DRUID); break;
                
                case Class.Hunter: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_HUNTER); break;
                
                case Class.Mage: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_MAGE); break;
                
                case Class.Paladin: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_PALADIN); break;
                
                case Class.Priest: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_PRIEST); break;
                
                case Class.Rogue: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_ROGUE); break;
                
                case Class.Shaman: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_SHAMAN); break;
                
                case Class.Warlock: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_WARLOCK); break;
                
                case Class.Warrior: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_WARRIOR); break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(classType), classType, null);
            }
        }
        private static void ChangeColor(SpriteRenderer sr, int i)
        {
            switch (i)
            {
                case 0: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_DRUID); break;
                
                case 1: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_HUNTER); break;
                
                case 2: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_MAGE); break;
                
                case 3: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_PALADIN); break;
                
                case 4: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_PRIEST); break;
                
                case 5: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_ROGUE); break;
                
                case 6: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_SHAMAN); break;
                
                case 7: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_WARLOCK); break;
                
                case 8: 
                    ChangeColor(sr, StringConstants.CLASS_COLOR_WARRIOR); break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(i), i, null);
            }
        }
        private static void ChangeColor(SpriteRenderer spriteRenderer, string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out Color newColor);
            spriteRenderer.color = newColor;
        }
        
        private ClassUnitData CreateHero(Class classType)
        {
            return classType switch
            {
                Class.Druid => _druid,
                Class.Hunter => _hunter,
                Class.Mage => _mage,
                Class.Paladin => _paladin,
                Class.Priest => _priest,
                Class.Rogue => _rogue,
                Class.Shaman => _shaman,
                Class.Warlock => _warlock,
                Class.Warrior => _warrior,
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
        Druid,
        Hunter,
        Mage,
        Paladin,
        Priest,
        Rogue,
        Shaman,
        Warlock,
        Warrior
    }

    [Serializable]
    public class Hero
    {
        public RaceUnitData raceUnitData;
        public ModelData modelData;
    }
}