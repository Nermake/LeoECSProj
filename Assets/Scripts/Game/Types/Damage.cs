using Leopotam.Ecs;

namespace Game.Types
{
    public struct Damage
    {
        public float Amount;
        public DamageType Type;
        public MagicType MagicType;
        public EcsEntity Instigator;
    }
}