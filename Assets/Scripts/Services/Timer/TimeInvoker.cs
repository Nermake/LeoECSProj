using System;
using UnityEngine;

namespace Timer
{
	public class TimeInvoker : MonoBehaviour
	{
		public event Action<float> UpdateTimeTicked;
		public event Action<float> UpdateTimeUnscaledTicked;
		public event Action OneSyncedSecondTicked;
		public event Action OneSyncedSecondUnscaledTicked;

		public static TimeInvoker instance
		{
			get
			{
				if (_instance == null)
				{
					var go = new GameObject("[TIME INVOKER]");
					_instance = go.AddComponent<TimeInvoker>();
					DontDestroyOnLoad(go);
				}

				return _instance;
			}
		}

		private static TimeInvoker _instance;

		private float _oneSecTimer;
		private float _oneSecUnscaledTimer;

		private void Update()
		{
			var deltaTimer = Time.deltaTime;
			
			UpdateTimeTicked?.Invoke(deltaTimer);

			_oneSecTimer += deltaTimer;
			
			if (_oneSecTimer >= 1f)
			{
				_oneSecTimer -= 1f;
				
				OneSyncedSecondTicked?.Invoke();
			}

			var unscaledDeltaTimer = Time.unscaledDeltaTime;
			
			UpdateTimeUnscaledTicked?.Invoke(Time.unscaledDeltaTime);
			
			_oneSecUnscaledTimer += unscaledDeltaTimer;
			
			if (_oneSecUnscaledTimer >= 1f)
			{
				_oneSecUnscaledTimer -= 1f;
				
				OneSyncedSecondUnscaledTicked?.Invoke();
			}
		}
	}
}