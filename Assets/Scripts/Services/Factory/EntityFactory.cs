using Leopotam.Ecs;
using UnityEngine;
using View;

namespace Services.Factory
{
    public class EntityFactory : IEntityFactory
    {
        private readonly EcsWorld _world;

        public EntityFactory(EcsWorld world)
        {
            _world = world;
        }

        public ref EcsEntity CreateUnitEntity(UnitConfig config, Vector3 location = default)
        {
            var builder = config.GetBuilder();

            builder.SetWorld(_world);
            builder.SetLocation(location);
            builder.Make();
            
            //ActorView entityView = builder.GetView();

            //InjectServices(entityView.gameObject);

            return ref builder.GetResult();
        }

        public ref EcsEntity CreateAbilityEntity(AbilityConfig config, EcsEntity owner, AbilityView view)
        {
            var builder = config.GetBuilder();
            
            builder.SetWorld(_world);
            builder.SetOwner(owner);
            builder.SetView(view);
            builder.Make();

            if (config.EffectConfigs.Count != 0)
            {
                foreach (var effectConfig in config.EffectConfigs)
                {
                    ref var effect = ref CreateAbilityEffectEntity(effectConfig, builder.GetResult());
                    builder.NewEffect(effect);
                }
            }
            
            return ref builder.GetResult();
        }

        public ref EcsEntity CreateAbilityEffectEntity(EffectConfig config, EcsEntity owner)
        {
            var builder = config.GetBuilder();
            
            builder.SetWorld(_world);
            //builder.SetOwner(owner);
            builder.Make();
            
            return ref builder.GetResult();
        }


        // public ref EcsEntity CreateWeaponEntity(WeaponConfig config, in EcsEntity owner, Transform socket)
        // {
        //     WeaponBuilder builder = config.GetBuilder();
        //
        //     builder.SetWorld(_world);
        //     builder.SetOwner(in owner);
        //     builder.SetWeaponSocket(socket);
        //     builder.Make();
        //
        //     return ref builder.GetResult();
        // }

        // public ref EcsEntity CreateProjectileEntity(ProjectileConfig config, in EcsEntity owner, Transform socket)
        // {
        //     ProjectileBuilder builder = config.GetBuilder();
        //     builder.SetWorld(_world);
        //     builder.SetOwner(owner);
        //     builder.SetLocation(socket.position);
        //     builder.SetRotation(socket.rotation);
        //     builder.Make();
        //
        //     return ref builder.GetResult();
        // }

        // public ref EcsEntity CreateArtifactEntity(ArtifactConfig config, in EcsEntity owner)
        // {
        //     ArtifactBuilder builder = config.GetBuilder();
        //     builder.SetWorld(_world);
        //     builder.SetOwner(owner);
        //     builder.Make();
        //
        //     return ref builder.GetResult();
        // }
    }
}
