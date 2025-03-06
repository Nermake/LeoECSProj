namespace Services.Factory
{
    public class ExperienceBuffBuilder : BuffBuilder
    {
        private readonly ExperienceBuffConfig _config;
        public ExperienceBuffBuilder(ExperienceBuffConfig config) : base(config) => _config = config;
    }
}