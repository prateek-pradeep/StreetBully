using UnityEngine;
using System.Collections;

public class PlayerTurretAttributes : IPlayerTurretAttributes
{			
		Parameter playerHealth;
		Parameter playerArmor;
		Parameter turretFireRate;
		Parameter bulletDamage;
		Parameter bulletsPerClip;
		float bulletHitForce;
		Parameter reloadTime;
		Parameter totalClips;
		WeaponType weaponType;

		public Parameter PlayerHealth	{ get { return playerHealth; } }
	
		public Parameter PlayerArmor { get { return playerArmor; } }
	
		public Parameter TurretFireRate { get { return turretFireRate; } }
	
		public Parameter BulletDamage { get { return bulletDamage; } }
	
		public Parameter BulletsPerClip { get { return bulletsPerClip; } }
	
		public float BulletHitForce { get { return bulletHitForce; } }
	
		public Parameter ReloadTime { get { return reloadTime; } }
	
		public Parameter TotalClips { get { return totalClips; } }

		public WeaponType WeaponType { get { return  weaponType; } }
	
		public float DamagePerSecond ()
		{
				return TurretFireRate.CurrentValue * BulletDamage.CurrentValue;
		}

		public PlayerTurretAttributes ()
		{
			
		}

		public void UpdatePlayerHealth (float value)
		{
				this.playerHealth.UpdateParameterValue (value);
		}

		public void UpdatePlayerArmor (float value)
		{
				this.playerArmor.UpdateParameterValue (value);
		}

		public void UpdateTurretFireRate (float value)
		{
				this.turretFireRate.UpdateParameterValue (value);
		}
		
		public void UpdateBulletDamage (float value)
		{
				this.bulletDamage.UpdateParameterValue (value);
		}

		public void UpdateBulletsPerClip (float value)
		{
				this.bulletsPerClip.UpdateParameterValue (value);
		}

		public void UpdateBulletHitForce (float value)
		{
				this.bulletHitForce = value;
		}

		public void UpdateReloadTime (float value)
		{
				this.reloadTime.UpdateParameterValue (value);
		}

		public void UpdateTotalClips (int value)
		{
				this.totalClips.UpdateParameterValue (value);
		}
		
}
