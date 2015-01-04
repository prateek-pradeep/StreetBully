using UnityEngine;
using System.Collections;

public class Preferences : Singleton<Preferences>
{

		const string  MAX_HEALTH = "maxhealth";
		const string  TOTAL_COINS = "totalcoins";

		public int MaxHealth {
				get;
				set;
		}
		
		int GetMaxHealth ()
		{
				if (!PlayerPrefs.HasKey (MAX_HEALTH)) {
						SaveMaxHealth (100);
				}

				return PlayerPrefs.GetInt (MAX_HEALTH);
		}

		void SaveMaxHealth (int health)
		{
				PlayerPrefs.SetInt (MAX_HEALTH, health);
		}

		int GetTotalCoins ()
		{
				if (!PlayerPrefs.HasKey (TOTAL_COINS)) {
						SaveMaxHealth (0);
				}
		
				return PlayerPrefs.GetInt (TOTAL_COINS);
		}
	
		void SaveTotalCoins (int coin)
		{
				PlayerPrefs.SetInt (TOTAL_COINS, coin);
		}
}
