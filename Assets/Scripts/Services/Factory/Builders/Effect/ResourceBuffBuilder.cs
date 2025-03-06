namespace Services.Factory
{
    public class ResourceBuffBuilder : BuffBuilder
    {
        private readonly ResourceBuffConfig _config;
        public ResourceBuffBuilder(ResourceBuffConfig config) : base(config) => _config = config;
    }
}