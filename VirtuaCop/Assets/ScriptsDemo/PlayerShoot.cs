using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

		public float timeBetweenBullets = 0.15f;
		public float rangeOfBullet = 100f;
		public float bulletSpeed = 200f;
		public GameObject Bullet;
		bool isFiring = false;
		float timer;
		Transform myTransform;

		void Awake ()
		{				
				myTransform = transform;						
		}
		
		public void Fire (Vector3 target)
		{				
				
				timer = 0f;				

				GameObject bullet = Instantiate (Bullet, myTransform.position, myTransform.rotation) as GameObject;
//				bullet.transform.rigidbody.AddRelativeForce (target * 100f);
				BulletAutoDestroy bullectScript = bullet.GetComponent<BulletAutoDestroy> ();							
				bullectScript.HitPosition (target);		

		}
			

		

		// Update is called once per frame
		void Update ()
		{
				timer += Time.deltaTime;	
				if (isFiring) {
					
				}
				
				//Debug.DrawLine (transform.position, hitPos, Color.green);
		}
}
