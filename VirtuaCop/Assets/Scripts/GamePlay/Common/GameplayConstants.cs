using UnityEngine;
using System.Collections;

public class GameplayConstants : Singleton<GameplayConstants>
{
		PlayerTurretAttributes currentPlayerTurretAttribute;
		
	#region Property

		public float PlayerHealth {
				get {
						return this.currentPlayerTurretAttribute.PlayerHealth.CurrentValue;
				}
				
		}

		public float PlayerArmor {
				get {
						return this.currentPlayerTurretAttribute.PlayerArmor.CurrentValue;
				}
		
		}

		public PlayerTurretAttributes CurrentPlayerTurretAttribute {
				get {
						return currentPlayerTurretAttribute;
				}
		}

		#endregion

	#region Private Method
		void Awake ()
		{
				//base.OnAwake ();		
			
				//TODO: Initialize player turret from game manager 
		}
	#endregion

	#region Public Method

		public void InitializePlayerTurretAttribute (PlayerTurretAttributes playerTurretAttributes)
		{
				if (currentPlayerTurretAttribute == null)
						currentPlayerTurretAttribute = new PlayerTurretAttributes ();
				
				this.currentPlayerTurretAttribute = playerTurretAttributes;
		}

		public void UpdatePlayerHealth (float value)
		{
				this.currentPlayerTurretAttribute.PlayerHealth.UpdateParameterValue (value);
		}

		public void UpdatePlayerArmor (float value)
		{
				this.currentPlayerTurretAttribute.PlayerArmor.UpdateParameterValue (value);
		}

	#endregion
}
