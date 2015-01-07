using UnityEngine;
using System.Collections;

public class Pistol : Weapon
{
		IPlayerTurretAttributes weaponAttribute;
		float timer;

		void Awake ()
		{
				base.OnAwake ();
				weaponType = WeaponType.Pistol;								
		}

		void OnEnable ()
		{				
				weaponAttribute = GameplayConstants.Instance.CurrentPlayerTurretAttribute;
				
//				this.bulletDamage = attribute.BulletDamage.CurrentValue;
//				this.bulletHitForce = attribute.BulletHitForce;
//				this.bulletsPerClip = attribute.BulletsPerClip.CurrentValue;
//				this.fireRate = attribute.TurretFireRate.CurrentValue;
//				this.reloadTime = attribute.ReloadTime.CurrentValue;
//				this.totalClips = attribute.TotalClips.CurrentValue;

		}

		void LateUpdate ()
		{
				//TODO: play audio
		}

		public void PlayerFire (Vector3 target)
		{				
//				if (weaponAttribute.BulletsPerClip.CurrentValue == 0) {
//						//TODO: send reload message
//						return;
//				}
				
				if (timer < Time.time) {
						//timer = Time.time + weaponAttribute.TurretFireRate.CurrentValue;
						timer = Time.time + 0.1f;
						FireShot (target);
				}		
		}

		void FireShot (Vector3 target)
		{
				//TODO: get bullet from pool 
				//BulletPoolGameObject bullet = ObjectPoolManager.Instance.GetObject (PoolObjectType.PlayerBullet) as BulletPoolGameObject;
					
				//bullet.BulletMovementScript.SetSourceAndTargetLocation (nozzlePosition, target);				
						
				//TODO: set bullet damage capacity
				//bullet.BulletAttributeScript.SetHealthAndArmorDamage()
		}

}
