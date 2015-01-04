using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{			
		Vector3 targetLocation;
		Transform myT;
		public float BulleetSpeed = 60f;

		// Use this for initialization
		void Awake ()
		{
				myT = transform;
		}
	
		void FixedUpdate ()
		{
				if (targetLocation != Vector3.zero) {						
						myT.position = Vector3.MoveTowards (myT.position, targetLocation, Time.deltaTime * BulleetSpeed);						
				}
		}

		public void SetSourceAndTargetLocation (Vector3 source, Vector3 target)
		{
				myT.position = source;
				targetLocation = target;
		}

}
