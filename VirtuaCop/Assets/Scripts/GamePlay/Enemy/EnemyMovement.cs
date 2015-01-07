using UnityEngine;
using System.Collections;
using PathologicalGames;

public enum EnemyMovementState
{
		None=0,
		InitialToFirstPoint,
		Firing,
		Translating,
		Cover,
}

public class EnemyMovement : MonoBehaviour
{
		public SpawnPointTypes enemyType;
		EnemyMovementState moveState;
		Transform myT;
		Vector3 firstPoint = Vector3.zero;
		float translationSpeed = 1f;
		Vector3 translationPoint = Vector3.zero;

		void Awake ()
		{
				myT = transform;
				enemyType = SpawnPointTypes.Fixed;
		}

		void OnEnable ()
		{	
				//Set Random Enemy type 
				
		}

		public void SetFixedPoint (Vector3 fixedPoint)
		{								
				firstPoint = fixedPoint;
				moveState = EnemyMovementState.InitialToFirstPoint;
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
//						if (myT.position != translationPoint)
//								myT.position = Vector3.Lerp (myT.position, translationPoint, translationSpeed * Time.deltaTime);
						iTween.MoveTo (gameObject, iTween.Hash (
						"x", translationPoint.x,
						"y", translationPoint.y,
						"z", translationPoint.z,
						"time", 1f,
						"easetype", iTween.EaseType.easeOutBack
						));
						moveState = EnemyMovementState.None;
						break;
				
				}
		}
}
