using System.Collections;

public interface IPlayerTurretAttributes
{
		Parameter PlayerHealth	{ get; }

		Parameter PlayerArmor { get; }
	
		Parameter TurretFireRate { get; }
	
		Parameter BulletDamage { get; }
	
		Parameter BulletsPerClip { get; }
	
		Parameter ReloadTime { get; }
	
		Parameter TotalClips { get; }

		float BulletHitForce { get; }

		WeaponType WeaponType{ get; }
	
		float DamagePerSecond (); 
}
