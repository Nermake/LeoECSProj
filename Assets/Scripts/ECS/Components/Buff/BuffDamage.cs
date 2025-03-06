using Game.Types;

namespace ECS.Components
{
    public struct BuffDamage
    {
        public float Amount;
        public bool IsAll;
        public DamageType DamageType;
        public MagicType MagicType;
    }
}