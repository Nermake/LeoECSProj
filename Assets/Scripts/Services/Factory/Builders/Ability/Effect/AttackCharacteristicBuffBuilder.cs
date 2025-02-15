namespace Services.Factory
{
    public class AttackCharacteristicBuffBuilder : BuffBuilder
    {
        private readonly AttackCharacteristicBuffConfig _config;
        public AttackCharacteristicBuffBuilder(AttackCharacteristicBuffConfig config) : base(config) => _config = config;
    }
}