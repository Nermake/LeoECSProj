using System;
using UnityEngine;

namespace Timer
{
	public delegate void TimerValueChangedHandler(float remainingSeconds, TimeChangingSource changingSource);

	public class SyncedTimer
	{
		public event TimerValueChangedHandler TimerValueChanged;
		public event Action TimerFinished;

		public TimerType Type { get; }
		public bool Active { get; private set; }
		public bool Paused { get; private set; }
		public float RemainingSeconds { get; private set; }

		public SyncedTimer(TimerType type)
		{
			Type = type;
		}

		public SyncedTimer(TimerType type, float seconds)
		{
			Type = type;

			SetTime(seconds);
		}
		
		public void SetTime(float seconds)
		{
			RemainingSeconds = seconds;
			TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimeForceChanged);
		}

		public void Start()
		{
			if (Active)
				return;

			if (Math.Abs(RemainingSeconds) < Mathf.Epsilon)
			{
#if DEBUG
				Debug.LogError("TIMER: You are trying start timer with remaining seconds equal 0.");
#endif
				TimerFinished?.Invoke();
			}

			Active = true;
			Paused = false;
			SubscribeOnTimeInvokerEvents();

			TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimerStarted);
		}

		public void Start(float seconds)
		{
			if (Active) return;

			SetTime(seconds);
			Start();
		}

		public void Pause()
		{
			if (Paused || !Active) return;

			Paused = true;
			UnsubscribeFromTimeInvokerEvents();

			TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimerPaused);
		}

		public void Resume()
		{
			if (!Paused || !Active) return;

			Paused = false;
			SubscribeOnTimeInvokerEvents();

			TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimerResume);
		}

		public void Stop()
		{
			if (!Active) return;
			
			UnsubscribeFromTimeInvokerEvents();
				
			RemainingSeconds = 0f;
			Active = false;
			Paused = false;

			TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimerFinished);
			TimerFinished?.Invoke();
		}

		private void SubscribeOnTimeInvokerEvents()
		{
			switch (Type)
			{
				case TimerType.UpdateTick:
					TimeInvoker.instance.UpdateTimeTicked += Ticked;
					break;
				case TimerType.UpdateTickUnscaled:
					TimeInvoker.instance.UpdateTimeUnscaledTicked += Ticked;
					break;
				case TimerType.OneSecTick:
					TimeInvoker.instance.OneSyncedSecondTicked += SyncedSecondTicked;
					break;
				case TimerType.OneSecTickUnscaled:
					TimeInvoker.instance.OneSyncedSecondUnscaledTicked += SyncedSecondTicked;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void UnsubscribeFromTimeInvokerEvents()
		{
			switch (Type)
			{
				case TimerType.UpdateTick:
					TimeInvoker.instance.UpdateTimeTicked -= Ticked;
					break;
				case TimerType.UpdateTickUnscaled:
					TimeInvoker.instance.UpdateTimeUnscaledTicked -= Ticked;
					break;
				case TimerType.OneSecTick:
					TimeInvoker.instance.OneSyncedSecondTicked -= SyncedSecondTicked;
					break;
				case TimerType.OneSecTickUnscaled:
					TimeInvoker.instance.OneSyncedSecondUnscaledTicked -= SyncedSecondTicked;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void CheckFinish()
		{
			if (RemainingSeconds <= 0f)
			{
				Stop();
			}
		}

		private void NotifyAboutTimePassed()
		{
			if (RemainingSeconds >= 0f)
			{
				TimerValueChanged?.Invoke(RemainingSeconds, TimeChangingSource.TimePassed);
			}
		}

		private void Ticked(float deltaTime)
		{
			RemainingSeconds -= deltaTime;
			
			NotifyAboutTimePassed();
			CheckFinish();
		}

		private void SyncedSecondTicked()
		{
			RemainingSeconds -= 1;
			
			NotifyAboutTimePassed();
			CheckFinish();
		}
	}
}