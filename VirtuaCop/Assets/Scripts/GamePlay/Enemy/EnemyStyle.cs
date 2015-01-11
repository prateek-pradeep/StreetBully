using UnityEngine;
using System.Collections;

public class EnemyStyle : MonoBehaviour
{

		public int numberOfShoot = 1;
		public int timeBetweenShoot = 1;
		
		protected bool IsReachPoint (Vector3 source, Vector3 targetPoint, float tolerance)
		{
				return Vector3.Distance (source, targetPoint) < tolerance;
		}

		void ShootOnce ()
		{
				
		}
}
