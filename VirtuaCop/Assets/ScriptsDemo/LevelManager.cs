using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void PlayLevel (Text levelName)
		{
				GameManager.Instance.SetLaodingLevelDetails (levelName.text);
				Application.LoadLevel ("Level");	
		}
}
