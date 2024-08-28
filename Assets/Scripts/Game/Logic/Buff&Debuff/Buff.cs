using Timer;
using UnityEngine;

namespace Game.Logic
{
    public class Buff : IBuff
    {
        public string Name { get; }
        public string Description { get; }
        public EStatusType Type { get; }
        
        public bool Negative { get; }
        public float Duration { get; }
        
        public void Apply()
        {
            Debug.Log("The buff has been successfully applied");
        }
    }
    
    public class BuffWithTick : IBuffWithTick
    {
        public string Name { get; }
        public string Description { get; }
        public EStatusType Type { get; }
        
        public bool Negative { get; }
        public float Duration { get; }
        public float TickRate { get; }

        private SyncedTimer _timerBuff;
        private SyncedTimer _timerTick;
        
        public void Apply()
        {
            Debug.Log("The buff with tick has been successfully applied");
            _timerBuff = new SyncedTimer(TimerType.OneSecTick, Duration);
            _timerBuff.Start();
            _timerBuff.TimerFinished += OnTimerFinished;
            
            //_timerTick = new SyncedTimer(TimerType.OneSecTick, TickRate);
            //_timerTick.Start();
            //_timerTick.TimerFinished += Tick;
        }

        private void OnTimerFinished()
        {
            _timerTick.TimerFinished -= Tick;
        }

        public void Tick()
        {
            Debug.Log("Tick()");
            _timerTick.Start(TickRate);
        }
    }

    public interface IBuff
    {
        string Name { get; }
        string Description { get; }
        EStatusType Type { get; }
        
        bool Negative { get; }
        float Duration { get; }
        
        void Apply();
    }

    public interface IBuffWithTick : IBuff
    {
        float TickRate { get; }
        
        void Tick();
    }

    public class BuffConfig
    {
        [field : SerializeField] public string Name { get; }
        [field : SerializeField] public string Description { get; }
        [field : SerializeField] public EStatusType Type { get; }
        
        [field : SerializeField] public bool Negative { get; }
        [field : SerializeField] public float Duration { get; }
        [field : SerializeField] public float TickRate { get; }
    }    
    
    public class BuffBuilder
    {
        private BuffConfig _config;
        private Buff _buff;

        public BuffBuilder(BuffConfig config)
        {
            _config = config;
        }

        public void Make()
        {
            if (_buff != null)
            {
                
            }
        }

        public Buff GetResult() => _buff;
    }
    
    public enum EStatusType : sbyte
    {
        Physical,
        Magic,
        Curse,
        Poison,
        Disease
    }
}