using ECS.Components;
using Leopotam.Ecs;

namespace Services.Factory
{
    public class HealBuffBuilder : BuffBuilder
    {
        private readonly HealBuffConfig _config;
        public HealBuffBuilder(HealBuffConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();

            ref var buffHeal = ref _entity.Get<BuffHeal>();
            buffHeal.Amount = _config.Amount;
        }
    }
}