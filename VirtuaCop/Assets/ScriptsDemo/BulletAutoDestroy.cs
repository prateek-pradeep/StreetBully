using UnityEngine;
using System.Collections;

public class BulletAutoDestroy : MonoBehaviour
{
		
		public float waitForTime = 2.0f;
		Transform myT;
		Vector3 hitTarget = Vector3.zero;
		// Use this for initialization
		void Awake ()
		{
				myT = transform;
	
		}

		void Start ()
		{
				Destroy (gameObject, 2f);
		}

		public void HitPosition (Vector3 target)
		{
				hitTarget = target;
				//hitTarget = myT.position + (target - myT.position).normalized * 50f;
				//myT.LookAt (target);
		}

		void FixedUpdate ()
		{
				if (hitTarget != Vector3.zero) {						
						myT.position = Vector3.MoveTowards (myT.position, hitTarget, Time.deltaTime * 60f);						
				}
		}

		void OnTriggerEnter (Collider other)
		{
				Destroy (gameObject);
		}
		
		
}
