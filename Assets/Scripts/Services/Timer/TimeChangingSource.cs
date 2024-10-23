namespace Services.Timer
{
    public enum TimeChangingSource
    {
        TimerStarted,
        TimerFinished,
        TimerPaused,
        TimerResume,
        TimePassed,
        TimeForceChanged
    }
}