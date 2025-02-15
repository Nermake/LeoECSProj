using ECS.Components;
using ECS.Flags;
using Leopotam.Ecs;

namespace Services.Factory
{
    public class BuffBuilder : EffectBuilder
    {
        private readonly BuffConfig _config;
        public BuffBuilder(BuffConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();

            if (_config.IsBuff)
                _entity.Get<BuffFlag>();
            else
                _entity.Get<DebuffFlag>();
            
            if (_config.IsPercentage)
                _entity.Get<BuffPercentageFlag>();
            else
                _entity.Get<BuffNumberFlag>();
            
            if (_config.IsInstant)
            {
                _entity.Get<AbilityInstantFlag>();
            }
            if (_config.Duration > 0)
            {
                ref var effectDurationComponent = ref _entity.Get<EffectDurationComponent>();
                effectDurationComponent.Duration = _config.Duration;
                
                ref var effectPeriodicComponent = ref _entity.Get<EffectPeriodicComponent>();
                effectPeriodicComponent.TickInterval = _config.TickInterval;
                
                ref var amountPerTickComponent = ref _entity.Get<AmountPerTickComponent>();
                amountPerTickComponent.Amount = _config.AmountPerTick;
            }
        }
    }
}