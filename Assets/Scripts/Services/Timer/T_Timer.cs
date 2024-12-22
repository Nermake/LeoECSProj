using QFSW.QC;
using Services.Timer;
using UnityEngine;

namespace Timer
{
    public class T_Timer : MonoBehaviour
    {
        private float Duration = 12;
        private float TickRate = 3;

        private SyncedTimer _timerBuff;

        private float _lastTick;
        
        [Command("t_apply")]
        public void Apply()
        {
            _lastTick = Duration;
            
            Debug.Log("The buff with Tick has been successfully applied");
            _timerBuff = new SyncedTimer(TimerType.OneSecTick, Duration);
            _timerBuff.Start();
            _timerBuff.TimerValueChanged += OnTimerValueChanged;
            _timerBuff.TimerFinished += OnTimerFinished;
        }

        private void OnTimerValueChanged(float remainingseconds, TimeChangingSource changingsource)
        {
            if (_lastTick - remainingseconds != TickRate) return;
            
            Debug.Log("Tick()" + remainingseconds);
            _lastTick = remainingseconds;
        }
        
        private void OnTimerFinished()
        {
            Debug.Log("The buff with Tick has been successfully finished");
            _timerBuff.TimerFinished -= OnTimerFinished;
            _timerBuff.TimerValueChanged -= OnTimerValueChanged;
        }
    }
}