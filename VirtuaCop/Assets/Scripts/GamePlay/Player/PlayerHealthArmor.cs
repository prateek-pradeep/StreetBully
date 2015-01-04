using UnityEngine;
using System.Collections;

public class PlayerHealthArmor : MonoBehaviour
{
			
		bool isDamaged;

		void OnTriggerEnter (Collider hit)
		{
				if (hit.gameObject.tag.Equals (Constants.BULLET_TAG)) {
						//get the bullet attribute script
						BulletAttribute bulletAttribute = hit.gameObject.GetComponent<BulletAttribute> ();
						GameplayConstants.Instance.UpdatePlayerHealth (-1 * bulletAttribute.HealthDamage);
						GameplayConstants.Instance.UpdatePlayerArmor (-1 * bulletAttribute.ArmorDamage);
						isDamaged = true;
				}
		}


		// Update is called once per frame
		void Update ()
		{
				//TODO update damage on screen

				if (isDamaged) {
						isDamaged = false;
						 
						//damageImage.color = flashDamageColor;
			
				} else {
						//damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
				}
		}
}
