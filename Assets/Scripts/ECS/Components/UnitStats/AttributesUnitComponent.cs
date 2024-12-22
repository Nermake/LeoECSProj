namespace ECS.Components
{
    public struct AttributesUnitComponent
    {
        public int Strength;
        public int Agility;
        public int Intelligence;
        
        public static AttributesUnitComponent operator +(AttributesUnitComponent a, AttributesUnitComponent b)
        {
            return new AttributesUnitComponent()
            {
                Strength = a.Strength + b.Strength,
                Agility = a.Agility + b.Agility,
                Intelligence = a.Intelligence + b.Intelligence,
            };
        }

        public override string ToString()
        {
            var massage = $"Strength: {Strength} \n" +
                          $"Agility: {Agility} \n" +
                          $"Intelligence: {Intelligence}";
            
            return massage;
        }
    }
}