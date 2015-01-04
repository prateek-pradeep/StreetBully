using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour
{

		void OnEnable ()
		{
				Invoke ("AutoDestroy", 2f);
		}
		
		void OnTriggerEnter ()
		{
				AutoDestroy ();
		}

		void AutoDestroy ()
		{
				gameObject.SetActive (false);
		}

		void Disable ()
		{
				CancelInvoke ();
		}
}
