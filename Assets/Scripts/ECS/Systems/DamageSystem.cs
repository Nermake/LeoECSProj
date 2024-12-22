using ECS.Components;
using Leopotam.Ecs;
using Logics.Displaying;

namespace ECS.Systems
{
    public class DamageSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly DamageIndicator _damageIndicator;

        private EcsFilter<DamageableComponent> _damageableFilter;

        public void Init()
        {
            
        }

        public void Run()
        {
            foreach (var i in _damageableFilter)
            {
                ref var entity = ref _damageableFilter.GetEntity(i);
                ref var damageableComponent = ref _damageableFilter.Get1(i);
                ref var viewComponent = ref entity.Get<DamageViewComponent>();

                if (damageableComponent.DamageQueue.Count > 0)
                {
                    var generalTotalDamage = 0.0f;

                    ref var healthComponent = ref entity.Get<HealthComponent>();

                    if (entity.Has<DefenseStatUnitComponent>())
                    {
                        ref var armorComponent = ref entity.Get<DefenseStatUnitComponent>();

                        for (var j = 0; j < damageableComponent.DamageQueue.Count; ++j)
                        {
                            var damage = damageableComponent.DamageQueue.Dequeue();
                            var totalDamage = damage.Amount;

                            if (damage.Instigator.IsAlive() == false) continue;
                            
                            ref var attackCharacteristicComponent = ref damage.Instigator.Get<AttackCharacteristicComponent>();
                            ref var instigatorView = ref damage.Instigator.Get<DamageViewComponent>();

                            // totalDamage -= Damage.Type switch
                            // {
                            //     DamageType.Physic => totalDamage * armorComponent.physicResistance,
                            //     DamageType.Magic => totalDamage * armorComponent.MagicResistance,
                            //     DamageType.Clear => 0,
                            //     _ => throw new ArgumentOutOfRangeException()
                            // }; todo

                            healthComponent.Current -= totalDamage;
                            generalTotalDamage += totalDamage;
                            
                            // var vampirism = totalDamage * attackCharacteristicComponent.Vampirism;
                            //
                            // if (vampirism > 0)
                            // {
                            //     ref var instigatorHealth = ref Damage.Instigator.Get<HealthComponent>();
                            //     instigatorHealth.Current += vampirism;
                            //     _damageIndicator.ShowHealthOnDisplay(vampirism, instigatorView.View.SelfTransform);
                            // } todo create a queue for vampirism

                            if (healthComponent.Current < 0.0f)
                            {
                                entity.Get<DeathFlag>();
                                break;
                            }
                        }

                    }
                    else
                    {
                        for (var j = 0; j < damageableComponent.DamageQueue.Count; ++j)
                        {
                            var damage = damageableComponent.DamageQueue.Dequeue();

                            if (damage.Instigator.IsAlive() == false) continue;

                            healthComponent.Current -= damage.Amount;
                            generalTotalDamage += damage.Amount;

                            if (healthComponent.Current < 0.0f)
                            {
                                entity.Get<DeathFlag>();
                                break;
                            }
                        }
                    }

                    if (generalTotalDamage > 0.0f)
                    {
                        _damageIndicator.ShowDamageOnDisplay(generalTotalDamage, viewComponent.View.SelfTransform);
                    }
                }
            }
        }
    }
}