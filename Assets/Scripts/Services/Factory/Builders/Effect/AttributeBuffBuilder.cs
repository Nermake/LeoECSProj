namespace Services.Factory
{
    public class AttributeBuffBuilder : BuffBuilder
    {
        private readonly AttributeBuffConfig _config;
        public AttributeBuffBuilder(AttributeBuffConfig config) : base(config) => _config = config;
    }
}