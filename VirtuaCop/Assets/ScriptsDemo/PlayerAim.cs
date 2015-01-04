using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
		public GameObject playerWeaponCollection;

		Transform myTransform;
		Quaternion newLookAt = Quaternion.identity;
		Vector3 newObjectPosition = Vector3.zero;
		Vector3 newObjectPosition1 = Vector3.zero;
		PlayerWeapon playerWeapon;

		void Awake ()
		{
				myTransform = transform;
				playerWeapon = playerWeaponCollection.GetComponent<PlayerWeapon> ();  

		}
		// Use this for initialization
		void Start ()
		{
		
		}
	
		void Destroy ()
		{
				
		}

		public void AimAt (Vector3 shootHitPoint)
		{
//				newObjectPosition = shootHitPoint - myTransform.localPosition;						
//				newObjectPosition1 = new Vector3 (newObjectPosition.x, newObjectPosition.y, newObjectPosition.z);
//				newObjectPosition.y = 0f;

				playerWeapon.FireWeaponAtTarget (shootHitPoint);
		}
		
		
		
}
