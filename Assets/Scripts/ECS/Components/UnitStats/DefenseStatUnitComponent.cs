namespace ECS.Components
{
    public struct DefenseStatUnitComponent
    {
        public int PhysicProtection;
        public float PercentageProtection;

        public int Resistance;
        public float PercentageResistance;

        public float Evasion;

        public static DefenseStatUnitComponent operator +(DefenseStatUnitComponent a, DefenseStatUnitComponent b)
        {
            return new DefenseStatUnitComponent()
            {
                PhysicProtection = a.PhysicProtection +b.PhysicProtection,
                Resistance = a.Resistance + b.Resistance,
                Evasion = a.Evasion + b.Evasion
            };
        }

        public override string ToString()
        {
            var massage = $"Protection: {PhysicProtection} \n" +
                          $"PercentageProtection: {PercentageProtection} \n" +
                          $"Resistance: {Resistance} \n" +
                          $"PercentageResistance: {PercentageResistance} \n" +
                          $"Evasion: {Evasion}";
            
            return massage;
        }
    }
}