using UnityEngine;
using System.Collections;

public class RoamAndShoot : EnemyStyle
{
		enum RoamAndShootState
		{
				None=0,
				Roam,
				Shoot,
		}
		
		public float roamingTimeInterval = 1f;
		public Transform[] roamPoints;
		GameObject myGO;
		Transform myT;
		RoamAndShootState currentState;
		int roamIndex;
		Vector3 targetRoamingPoint;
		bool isShootTriggered;

		public void SetRoamPointsAndResetState (Transform[] roamPoints)
		{
				this.roamPoints = roamPoints;
				SetCurrentState (RoamAndShootState.Roam);
		}

		void OnEnable ()
		{

		}

		void Awake ()
		{
				myGO = gameObject;
				myT = transform;	
				ResetVariables ();
				SetCurrentState (RoamAndShootState.Roam);
		}

		// Use this for initialization
		void Start ()
		{
	
		}
		
		// Update is called once per frame
		void Update ()
		{
				if (roamPoints == null) {
						return;
				}

				switch (currentState) {
				case RoamAndShootState.Roam:
						MoveToRaomingPoint ();
						if (IsReachTargetRoamingPoint ()) {
								SetCurrentState (RoamAndShootState.Shoot);
						}
						break;

				case RoamAndShootState.Shoot:
						if (!isShootTriggered)
				// if shooting is not triggere then enable shooting
								StartCoroutine (Shoot ());
						break;
				}
	
		}

		void OnDisable ()
		{
				ResetVariables ();
		}

		IEnumerator Shoot ()
		{
				//set shooting trigger as true so that it is not repeated continuosly in update
				isShootTriggered = true;
		
				//shoot for number times
				for (int i=0; i<numberOfShoot; i++) {						
						Debug.Log ("RoamingShoot " + i);
						yield return new WaitForSeconds (timeBetweenShoot);
				}
		
				//after shooting is done, hide 
				SetCurrentState (RoamAndShootState.Roam);
				
				//	Get next roaming point from array
				targetRoamingPoint = GetNextRoamPoints ();

				//reset trigger so that is works for the next time
				isShootTriggered = false;
		}

		void ResetVariables ()
		{
				//targetRoamingPoint = Vector3.zero;
				roamIndex = 0;
				isShootTriggered = false;
		}

		bool IsReachTargetRoamingPoint ()
		{
				return IsReachPoint (myT.position, targetRoamingPoint, 0.1f);
		}

		void MoveToRaomingPoint ()
		{
				iTween.MoveUpdate (myGO, targetRoamingPoint, roamingTimeInterval);
		}
		
		Vector3 GetNextRoamPoints ()
		{
				return this.roamPoints [++roamIndex % this.roamPoints.Length].position;
		}

		void SetCurrentState (RoamAndShootState state)
		{
				this.currentState = state;
		}
}
