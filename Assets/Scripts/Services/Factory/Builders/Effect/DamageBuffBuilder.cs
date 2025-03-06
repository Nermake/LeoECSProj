namespace Services.Factory
{
    public class DamageBuffBuilder : BuffBuilder
    {
        private readonly DamageBuffConfig _config;
        public DamageBuffBuilder(DamageBuffConfig config) : base(config) => _config = config; 
    }
}