using UnityEngine;
using System.Collections;

public class EnemyHealth : EnemyBase
{
		public float damageColorRate = 5;
		public ParticleSystem hitParticle;
		int health = 99;
		bool isDamage;
		Color dagameColor = Color.red;

		void Awake ()
		{
				base.Awake ();
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag.Equals ("Bullet")) {
						health -= 35;
						isDamage = true;
				}
		}

		void Update ()
		{
				if (isDamage) {
						selfmaterial.color = dagameColor;
						isDamage = false;
				} else {
						selfmaterial.color = Color.Lerp (selfmaterial.color, originalColor, Time.deltaTime * damageColorRate);
				}

				if (health < 0) {						
						hitParticle = Instantiate (hitParticle) as ParticleSystem;
						hitParticle.transform.position = myTransform.position;
						hitParticle.startColor = originalColor;
						hitParticle.Play ();
						GamePlay.Instance.TotalEnemiesKilled++;
						Destroy (gameObject);
				}
		}
}
