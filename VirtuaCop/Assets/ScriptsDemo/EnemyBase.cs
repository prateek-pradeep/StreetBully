using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{

		protected Transform player;
		protected Transform myTransform;
		protected Material selfmaterial;
		protected Color originalColor ;

		public Color EnemyColor {
				get {
						return originalColor;
				}				
		}

		// Use this for initialization
		protected void Awake ()
		{
				player = GameObject.FindGameObjectWithTag ("PlayerHead").transform;
				myTransform = transform;
				selfmaterial = renderer.material;
				originalColor = selfmaterial.color;
		}

}
