using System;

namespace Game.Types
{
    [Flags]
    public enum AbilityState : sbyte
    {
        None = 0,
        Cooldown = 1 << 0,
        EnoughResource = 1 << 1,
        Ready = 1 << 3,
        Lock = 1 << 4,
    }
}