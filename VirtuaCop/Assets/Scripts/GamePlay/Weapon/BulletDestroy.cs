using UnityEngine;
using System.Collections;
using PathologicalGames;

public class BulletDestroy : MonoBehaviour
{
		Transform myT;

		void Awake ()
		{
				myT = transform;
		}

		void OnEnable ()
		{
				if (PoolManager.Pools.ContainsKey ("PlayerBullet"))
						PoolManager.Pools ["PlayerBullet"].Despawn (myT, 2);
				
		}
		
		void OnTriggerEnter ()
		{
				PoolManager.Pools ["PlayerBullet"].Despawn (transform);

				AutoDestroy ();
		}

		void AutoDestroy ()
		{		 				
				//gameObject.SetActive (false);
		}

		void Disable ()
		{
				CancelInvoke ();
		}
}
