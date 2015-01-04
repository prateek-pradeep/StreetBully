﻿using UnityEngine;
using System.Collections;

public class FPSScript : MonoBehaviour
{
		public float updateInterval = 0.5F;
		private float lastInterval;
		private int frames = 0;
		private float fps;

		void Start ()
		{
				lastInterval = Time.realtimeSinceStartup;
				frames = 0;
		
				Application.targetFrameRate = 60;
		
		}

		void OnGUID ()
		{
				GUILayout.Label ("" + fps.ToString ("f2"));
		}

		void Update ()
		{
				++frames;
				float timeNow = Time.realtimeSinceStartup;
				if (timeNow > lastInterval + updateInterval) {
						fps = frames / (timeNow - lastInterval);
						frames = 0;
						lastInterval = timeNow;
				}
		}
}

