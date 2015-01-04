using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemySign : EnemyBase
{

		Compass direction;
		bool isChecking = false;
		public GameObject signImage;
		Transform signParent;
		GameObject sign;
		RectTransform signRect;
		RectTransform signParentRect;
		Image signImageComponent;
		Vector3 screenPosition;
		// Use this for initialization
		void Start ()
		{
				signParent = (GameObject.FindGameObjectWithTag ("EnemySign") as GameObject).transform;

				sign = Instantiate (signImage) as GameObject;
				sign.transform.SetParent (signParent, false);

				signRect = sign.GetComponent<RectTransform> ();
				signParentRect = signParent.GetComponent<RectTransform> ();
				
				signImageComponent = sign.GetComponent<Image> ();
				sign.SetActive (false);				
		}

		void OnDestroy ()
		{
				Destroy (sign);
		}

		void Update ()
		{
				OffSCreenTarget2 ();				
		}

		void OffSCreenTarget2 ()
		{
				Vector3 screenPos = Camera.main.WorldToViewportPoint (myTransform.position);
				if (screenPosition == screenPos)
						return;

				if (screenPos.x >= 0.0f && screenPos.x <= 1.0f && screenPos.y >= 0.0f && screenPos.y <= 1.0f) {
						sign.SetActive (false);				
				} else {
						sign.SetActive (true);
						if (screenPos.z < 0) {
								screenPos *= -1f;
						}
						screenPos.x -= 0.5f;
						screenPos.y -= 0.5f;

						float angle = Mathf.Atan2 (screenPos.x, screenPos.y);
						signRect.localEulerAngles = new Vector3 (0.0f, 0.0f, -angle * Mathf.Rad2Deg);
			
						screenPos.x = 0.495f * Mathf.Sin (angle) + 0.5f;  // Place on ellipse touching 
						screenPos.y = 0.5f * Mathf.Cos (angle) + 0.5f;  //   side of viewport
						screenPos.z = Camera.main.nearClipPlane + 0.01f;  // Looking from neg to pos Z;
						

						Vector2 local = Camera.main.ViewportToScreenPoint (screenPos);
						signImageComponent.color = selfmaterial.color;
						if (RectTransformUtility.ScreenPointToLocalPointInRectangle (signParentRect, local, null, out local)) {
								signRect.localPosition = local;
						}


				}
		
		}								
		
}
