using UnityEngine;
using System.Collections;

public class HideAndShoot : EnemyStyle
{

		enum HideAndShootState
		{
				None=0,
				Hide=1,
				Appear=2,
				Shoot=3,
				
		}

		public float travellingTime = 1f;
		public Transform hidePoint ;
		public Transform shootPoint ;
		HideAndShootState currentState;
		GameObject myGO;
		Transform myT;
		bool isShootTriggered;
		
		/// <summary>
		/// Set the hide and shoot points so that object can work properly
		/// </summary>
		/// <param name="hidePoint">Hide point.</param>
		/// <param name="shootPoint">Shoot point.</param>
		public void SetPointsAndResetState (Transform hidePoint, Transform shootPoint)
		{
				this.hidePoint = hidePoint;
				this.shootPoint = shootPoint;

				//Set the default state as hide
				SetCurrentState (HideAndShootState.Hide);
		}

		void Awake ()
		{
				myT = transform;
				myGO = gameObject;
				isShootTriggered = false;
		}
		
		void OnEnable ()
		{
				
				SetCurrentState (HideAndShootState.Hide);
		}

		// Update is called once per frame
		void Update ()
		{
				switch (currentState) {
				case HideAndShootState.Hide:
						//Move to hide spawn point
						GoToHidePoint (travellingTime);
						if (IsRechedHidePoint ()) {
								// change state to appear if hide is reached
								SetCurrentState (HideAndShootState.Appear);
						}						
						break;
				case HideAndShootState.Appear:
						//Move to Shoot point
						GoToShootPoint (travellingTime);
						if (IsReachShootPoint ()) {
								//change state to shoot
								SetCurrentState (HideAndShootState.Shoot);
						}
						break;
				case HideAndShootState.Shoot:
						if (!isShootTriggered)
								// if shooting is not triggere then enable shooting
								StartCoroutine (Shoot ());
						break;
				}
		}

		void OnDisable ()
		{
				ResetLocalParameter ();
		}
		
		IEnumerator Shoot ()
		{
				//set shooting trigger as true so that it is not repeated continuosly in update
				isShootTriggered = true;

				//shoot for number times
				for (int i=0; i<numberOfShoot; i++) {						
						Debug.Log ("HideAndShoot: " + i);
						yield return new WaitForSeconds (timeBetweenShoot);
				}

				//after shooting is done, hide 
				SetCurrentState (HideAndShootState.Hide);
				
				//reset trigger so that is works for the next time
				isShootTriggered = false;
		}

		/// <summary>
		/// Resets the local parameter.
		/// </summary>
		void ResetLocalParameter ()
		{
				ResetPoint ();
				isShootTriggered = false;
		}

		void SetCurrentState (HideAndShootState state)
		{
				this.currentState = state;
		}
		
		bool IsReachShootPoint ()
		{
				return IsReachPoint (myT.position, this.shootPoint.position,0.1f);
		}

		bool IsRechedHidePoint ()
		{
				return IsReachPoint (myT.position, this.hidePoint.position,0.1f);
		}
		
		void GoToShootPoint (float time)
		{
				GoToPoint (time, this.shootPoint.position);
		}

		void GoToHidePoint (float time)
		{
				GoToPoint (time, this.hidePoint.position);
		}

		void GoToPoint (float time, Vector3 targetPoint)
		{
				iTween.MoveUpdate (myGO, targetPoint, time);
		}

		void ResetPoint ()
		{
				this.hidePoint = null;
				this.shootPoint = null;
		}

		


}
