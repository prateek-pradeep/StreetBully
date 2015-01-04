using UnityEngine;
using System.Collections;

public class BulletAttribute:MonoBehaviour
{
		public float HealthDamage {
				get;
				set;
		}

		public float ArmorDamage {
				get;
				set;
		}

		public void SetHealthAndArmorDamage (float health, float armor)
		{
				HealthDamage = health;
				ArmorDamage = armor;
		}
}
