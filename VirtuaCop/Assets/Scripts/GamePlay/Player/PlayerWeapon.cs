using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
		Transform myT;
		GameObject activeWeapon;
		// Use this for initialization
		void Start ()
		{
				myT = transform;

				//TODO: get the user selected weapon type from Game Manager
				SelectWeapon (WeaponType.Pistol);
		}

		void SelectWeapon (WeaponType selectedWeapon)
		{
				foreach (Transform child in myT) {
						Weapon weapon = child.gameObject.GetComponent<Weapon> ();

						if (weapon == null) {
								Debug.LogError (child.name + " gameobject has no WEAPON script attached");
								continue;
						}

						//enable the selected weapon and disable rest
						if (weapon.WeaponType == selectedWeapon) {
								activeWeapon = child.gameObject;
								activeWeapon.SetActive (true);								
								break;
						} else {
								child.gameObject.SetActive (false);
						}
				}
		}
		
		public void FireWeaponAtTarget (Vector3 target)
		{
				activeWeapon.SendMessage ("Fire", target, SendMessageOptions.DontRequireReceiver);
		}

}
