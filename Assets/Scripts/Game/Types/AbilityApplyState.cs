namespace Game.Types
{
    public enum AbilityApplyState : sbyte
    {
        Free, // = NoCast + NoRes (Flag)
        Clear, // = NoRes (Flag)
        Instant, // = NoCast (Flag)
        Normal // 
    }
}