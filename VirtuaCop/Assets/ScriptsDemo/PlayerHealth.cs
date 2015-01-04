using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
		Parameter playerHealth;
		public Slider healthSlider;
		public Image damageImage;
		Color flashDamageColor = new Color (1f, 0f, 0f, 0.2f);
		float flashSpeed = .5f;
		bool isDamaged;
		
		void Start ()
		{
				playerHealth = GameplayConstants.Instance.CurrentPlayerTurretAttribute.PlayerHealth;
		}

		void OnTriggerEnter (Collider hit)
		{
				isDamaged = true;
				playerHealth.CurrentValue -= 5;
				healthSlider.value = playerHealth.CurrentValue;

		}

		void Update ()
		{
				if (isDamaged) {
						isDamaged = false;
						damageImage.color = flashDamageColor;
						
				} else {
						damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
				}

				if (playerHealth.CurrentValue <= playerHealth.MinValue) {
						GamePlay.Instance.isEnd = true;
						GamePlayUI.Instance.SetYouLooseMesssage ();
				}
		}
		
}
