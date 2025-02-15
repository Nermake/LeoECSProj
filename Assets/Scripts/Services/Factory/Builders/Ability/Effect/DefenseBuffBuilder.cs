namespace Services.Factory
{
    public class DefenseBuffBuilder : BuffBuilder
    {
        private readonly DefenseBuffConfig _config;
        public DefenseBuffBuilder(DefenseBuffConfig config) : base(config) => _config = config;
    }
}