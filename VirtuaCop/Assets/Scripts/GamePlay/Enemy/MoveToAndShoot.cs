using UnityEngine;
using System.Collections;

public class MoveToAndShoot : EnemyStyle
{
		enum MoveToAndShootState
		{
				None=0,
				Travel,
				Shoot
		}

		public float totalMoveTime = 4f;
		public Transform[] wayPoints;
		float shootInterval = 2f;
		MoveToAndShootState currentState;
		GameObject myGO;
		Transform myT;
		float movePercentage;
		bool isShootTriggered;

		public void SetWayPointsAndResetState (Transform[] wayPoints)
		{
				this.wayPoints = wayPoints;
				SetCurrentState (MoveToAndShootState.Travel);
		}

		void Awake ()
		{
				myGO = gameObject;
				myT = transform;
		}
		// Use this for initialization
		void Start ()
		{
				totalMoveTime = totalMoveTime / 10f;
				SetCurrentState (MoveToAndShootState.Travel);
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (wayPoints == null)
						return;

				switch (currentState) {
				case MoveToAndShootState.Travel:												
						MoveThroughWaypoints ();						
						break;
				case MoveToAndShootState.Shoot:						
						Shoot ();
						break;
				}
		}
		
		void MoveThroughWaypoints ()
		{
				movePercentage = Mathf.Lerp (0f, 1f, Time.time * totalMoveTime);
				iTween.PutOnPath (myGO, wayPoints, movePercentage);
				if (movePercentage == 1) {
						SetCurrentState (MoveToAndShootState.Shoot);
				}
		}

		void SetCurrentState (MoveToAndShootState state)
		{
				currentState = state;
		}

		void ShootIndefinitely ()
		{
				Debug.Log ("Shoot");
		}

		void Shoot ()
		{
				if (isShootTriggered)
						return;
				isShootTriggered = true;
				InvokeRepeating ("ShootIndefinitely", shootInterval, shootInterval);
		}

		void OnDrawGizmos ()
		{				
				//iTween.DrawPath (wayPoints, Color.magenta);
		}
}
