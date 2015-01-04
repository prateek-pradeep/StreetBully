using UnityEngine;
using System.Collections;

public class EnemyShoot : EnemyBase
{
		
		public GameObject Bullet;
		float fireRate = 2f;
		float timer;
		Transform nozzle;

		void Awake ()
		{
				base.Awake ();
				foreach (Transform child in myTransform) {
						if (child.name.Equals ("Nozzle")) {
								nozzle = child;
								break;
						}
				}
		}

		// Use this for initialization
		void Start ()
		{				
				fireRate = Random.Range (2, 5);								
				
		}
	
		// Update is called once per frame
		void Update ()
		{							
				if (GamePlay.Instance.isEnd || GamePlay.Instance.isPause)
						return;
				timer += Time.deltaTime;	
				if (timer > fireRate) {						
						Fire (player.position);

				}							
		}

		void LateUpdate ()
		{
				myTransform.LookAt (player);
		}

		public void Fire (Vector3 target)
		{						
				timer = 0f;						
				GameObject bullet = Instantiate (Bullet, nozzle.position, nozzle.rotation) as GameObject;
				BulletAutoDestroy bullectScript = bullet.GetComponent<BulletAutoDestroy> ();							
				bullectScript.HitPosition (target);														
		}
}
