using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{		
		protected  WeaponType weaponType;
		protected float bulletDamage;
		protected float bulletHitForce;
		protected float reloadTime ;
		protected float totalClips;
		protected float bulletsPerClip ;
		protected float fireRate;
		
		protected Vector3 nozzlePosition;
		protected Transform myT;

		public WeaponType WeaponType {
				get{ return weaponType;}			
		}
		
		protected void OnAwake ()
		{
				myT = transform;
				weaponType = WeaponType.Pistol;
		
				foreach (Transform child in myT) {
						if (child.tag.Equals (Constants.NOZZLE_TAG)) {
								nozzlePosition = child.position;
								break;
						}
				}
		}
		
}
