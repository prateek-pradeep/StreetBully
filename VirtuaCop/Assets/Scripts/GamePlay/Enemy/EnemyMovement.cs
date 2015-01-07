using UnityEngine;
using System.Collections;

public enum EnemyMovementState
{
		InitialToFirstPoint=0,
		Firing,
		Translating,
		Cover,
}

public class EnemyMovement : MonoBehaviour
{
		SpawnPointTypes enemyType;
		EnemyMovementState moveState;
		Transform myT;
		Vector3 firstPoint = Vector3.zero;
		float translationSpeed = 4f;
		Vector3 translationPoint = Vector3.zero;

		void Awake ()
		{
				myT = transform;
		}

		void OnEnable ()
		{	
				//Set Random Enemy type 
				enemyType = SpawnPointTypes.Fixed;
		}

		public void SetFixedPoint (Vector3 fixedPoint)
		{				
				firstPoint = fixedPoint;
		}

		// Update is called once per frame
		void Update ()
		{
	
				switch (moveState) {
				case EnemyMovementState.InitialToFirstPoint:
						translationPoint = firstPoint;
						moveState = EnemyMovementState.Translating;
						break;
				case EnemyMovementState.Translating:
						if (myT.position != translationPoint)
								myT.position = Vector3.Lerp (myT.position, translationPoint, translationSpeed * Time.deltaTime);
						break;
				}
		}
}
