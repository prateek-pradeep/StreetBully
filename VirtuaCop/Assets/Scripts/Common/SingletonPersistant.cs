using UnityEngine;
using System.Collections;

public class SingletonPersistant<T> : MonoBehaviour where T : MonoBehaviour
{
		protected static T instance;
	
		/**
      Returns the instance of this singleton.
   */
		public static T Instance {
				get {
												
						return instance;
				}
		}

		void Awake ()
		{
				if (instance == null) {
						instance = (T)GameObject.FindObjectOfType (typeof(T));
			
						if (instance == null) {
								Debug.LogError ("An instance of " + typeof(T) + 
										" is needed in the scene, but there is none.");
						}
						DontDestroyOnLoad (gameObject);
				} else {
						Destroy (gameObject);
				}
		}
}