﻿using UnityEngine;
using System.Collections;

public class DieParticleSystem : MonoBehaviour
{

		ParticleSystem particleSystem ;
		// Use this for initialization
		void Start ()
		{
				particleSystem = GetComponent<ParticleSystem> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (!particleSystem.IsAlive ()) {
						Destroy (gameObject);
				}
	
		}
}
