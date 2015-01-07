using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
		//object for locking
		private static object syncRoot = new System.Object ();

		//the variable is declared to be volatile to ensure that 
		//assignment to the instance variable completes before the 
		//		//instance variable can be accessed.
		private volatile static T instance;

		//  Returns the instance of this singleton.
   
		public static T Instance {
				get {
						if (instance == null) {
								lock (syncRoot) {
										instance = GameObject.FindObjectOfType<T> ();							
				
										if (instance == null) {
												Debug.LogError ("An instance of " + typeof(T) + 
														" is needed in the scene, but there is none.");
										}
								} 
						}
						return instance;
				}
		}


}