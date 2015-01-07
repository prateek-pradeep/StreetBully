using UnityEngine;
using System.Collections;

public class Shotgun : Weapon
{

		IPlayerTurretAttributes weaponAttribute;
		float timer;
	
		void Awake ()
		{
				base.OnAwake ();
				weaponType = WeaponType.Shotgun;								
		}
	
		void OnEnable ()
		{				
				weaponAttribute = GameplayConstants.Instance.CurrentPlayerTurretAttribute;				
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
						timer = Time.time + 0.5f;
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
