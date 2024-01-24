using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif

namespace NonStandard
{
	public class LifeCycle : MonoBehaviour
	{
		private static LifeCycle s_instance;
		public static LifeCycle Instance
        {
			get
            {
				if(s_instance != null)
                {
					return s_instance;
                }
				s_instance = FindObjectOfType<LifeCycle>();
				if(s_instance != null)
                {
					return s_instance;
                }
				GameObject gObj = new GameObject();
				s_instance = gObj.AddComponent<LifeCycle>();
				return s_instance;
                
            }
        }
		//public static LifeCycle Instance => Global.GetComponent<LifeCycle>();
#if UNITY_EDITOR
		public LifeCycleEvents lifeCycleEditor = new LifeCycleEvents();
#endif
#if UNITY_EDITOR || UNITY_WEBPLAYER
		public LifeCycleEvents lifeCycleWebPlayer = new LifeCycleEvents();
#endif
#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE
		public LifeCycleEvents lifeCycleMobile = new LifeCycleEvents();
#endif
		public PauseEvents pauseEvents = new PauseEvents();
		private static HashSet<LifeCycle> lifeCycles = new HashSet<LifeCycle>();
		private static bool _isPaused;
		private static float originalTimeScale = 1;
		public bool isPaused
		{
			get => _isPaused;
			set
			{
				if (value == isPaused) return;
				if (value) { Pause(); } else { Unpause(); }
			}
		}
		[System.Serializable]
		public class LifeCycleEvents
		{
			public UnityEvent onStart;
			public UnityEvent onDestroy;
		}
		[System.Serializable]
		public class PauseEvents
		{
			[Tooltip("do this when time is paused")] public UnityEvent onPause = new UnityEvent();
			[Tooltip("do this when time is unpaused")] public UnityEvent onUnpause = new UnityEvent();
		}
		private void Awake()
		{
			s_instance = this;
			lifeCycles.Add(this);
		}
		void Start()
		{
#if UNITY_EDITOR
			lifeCycleEditor.onStart.Invoke();
#endif
#if UNITY_WEBPLAYER
				lifeCycleWebPlayer.onStart.Invoke();
#endif
#if UNITY_ANDROID || UNITY_IPHONE
				lifeCycleMobile.onStart.Invoke();
#endif
		}
		private void OnDestroy()
		{
#if UNITY_EDITOR
			lifeCycleEditor.onDestroy.Invoke();
#endif
#if UNITY_WEBPLAYER
				lifeCycleWebPlayer.onDestroy.Invoke();
#endif
#if UNITY_ANDROID || UNITY_IPHONE
				lifeCycleMobile.onDestroy.Invoke();
#endif
		}
		private void Reset()
		{
#if UNITY_EDITOR
			//Utility.Event.Bind(pauseEvents.onPause, this, nameof(FreezeTime));
			UnityEventTools.AddVoidPersistentListener(pauseEvents.onPause, FreezeTime);
			UnityEventTools.AddVoidPersistentListener(pauseEvents.onUnpause, UnfreezeTime);
			//Utility.Event.Bind(pauseEvents.onUnpause, this, nameof(UnfreezeTime));
#else
			pauseEvents.onPause.AddListener(FreezeTime);
			pauseEvents.onUnpause.AddListener(UnfreezeTime);
#endif
		}
		public void Quit() { Exit(); }

		public static void Exit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
#else
			Application.Quit();
#endif
		}
		public void Pause()
		{
			//Debug.Log("im pausing");
			ImportantVars.Instance.StartCoroutine(pauseNextFrame());
			IEnumerator pauseNextFrame()
			{
				yield return null;
				if (_isPaused) yield break;
				_isPaused = true;
				foreach (LifeCycle lc in lifeCycles)
				{
					if (lc.pauseEvents.onPause != null) { lc.pauseEvents.onPause.Invoke(); }
				}
			}
		}
		public void Unpause()
		{
			if (!_isPaused) return;
			_isPaused = false;
			foreach (LifeCycle lc in lifeCycles)
			{
				if (lc.pauseEvents.onUnpause != null) { lc.pauseEvents.onUnpause.Invoke(); }
			}
		}
		public void FreezeTime()
		{
			if (Time.timeScale == 0) { return; }
			originalTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		public void UnfreezeTime()
		{
			if (originalTimeScale == 0) { return; }
			Time.timeScale = originalTimeScale;
		}
	}
}