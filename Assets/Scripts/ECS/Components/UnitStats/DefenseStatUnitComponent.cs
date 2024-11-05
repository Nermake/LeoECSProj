using System;

namespace ECS.Components
{
    [Serializable]
    public struct DefenseStatUnitComponent
    {
        public int protection;
        public float percentageProtection;

        public int resistance;
        public float percentageResistance;

        public float evasion;

        public static DefenseStatUnitComponent operator +(DefenseStatUnitComponent a, DefenseStatUnitComponent b)
        {
            return new DefenseStatUnitComponent()
            {
                protection = a.protection +b.protection,
                resistance = a.resistance + b.resistance,
                evasion = a.evasion + b.evasion
            };
        }

        public override string ToString()
        {
            var massage = $"protection: {protection} \n" +
                          $"percentageProtection: {percentageProtection} \n" +
                          $"resistance: {resistance} \n" +
                          $"percentageResistance: {percentageResistance} \n" +
                          $"evasion: {evasion}";
            
            return massage;
        }
    }
}