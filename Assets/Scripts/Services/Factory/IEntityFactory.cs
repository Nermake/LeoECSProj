using Leopotam.Ecs;
using UnityEngine;
using View;

namespace Services.Factory
{
    public interface IEntityFactory
    {
        //ref EcsEntity CreateArtifactEntity(ArtifactConfig config, in EcsEntity owner);
        ref EcsEntity CreateUnitEntity(UnitConfig config, Vector3 location = default);
        ref EcsEntity CreateAbilityEntity(AbilityConfig config, in EcsEntity owner, AbilityView view);
        ref EcsEntity CreateAbilityEffectEntity(EffectConfig config, in EcsEntity owner);
        //ref EcsEntity CreateProjectileEntity(ProjectileConfig config, in EcsEntity owner, Transform socket);
        //ref EcsEntity CreateWeaponEntity(WeaponConfig config, in EcsEntity owner, Transform socket);
    }
}