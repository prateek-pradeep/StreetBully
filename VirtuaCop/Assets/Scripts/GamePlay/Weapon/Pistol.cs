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
				this.nextFireTime = 0f;
				
//				this.bulletDamage = attribute.BulletDamage.CurrentValue;
//				this.bulletHitForce = attribute.BulletHitForce;
//				this.bulletsPerClip = attribute.BulletsPerClip.CurrentValue;
//				this.fireRate = attribute.TurretFireRate.CurrentValue;
//				this.reloadTime = attribute.ReloadTime.CurrentValue;
//				this.totalClips = attribute.TotalClips.CurrentValue;

		}
		
		public void Fire (Vector3 target)
		{				
//				if (weaponAttribute.BulletsPerClip.CurrentValue == 0) {
//						//TODO: send reload message
//						return;
//				}
				
				if (timer < Time.time) {
						//timer = Time.time + weaponAttribute.TurretFireRate.CurrentValue;
						timer = Time.time + 0.5f;
						FireShot (target);
				}
		
		}
			
		void LateUpdate ()
		{
				//TODO: play audio
		}

		void FireShot (Vector3 target)
		{
				//TODO: get bullet from pool 
				BulletPoolGameObject bullet = ObjectPoolManager.Instance.GetObject (PoolObjectType.PlayerBullet) as BulletPoolGameObject;
					
				bullet.BulletMovementScript.SetSourceAndTargetLocation (nozzlePosition, target);
				//bullet.BulletAttributeScript.SetHealthAndArmorDamage()
						
				//TODO: set source and target position, bullet damage capacity
		}

}
