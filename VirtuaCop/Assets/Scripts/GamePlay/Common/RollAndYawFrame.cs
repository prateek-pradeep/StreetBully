using UnityEngine;
using System.Collections;

public class RollAndYawFrame : MonoBehaviour
{
		Compass direction;
		TKSwipeRecognizer swipeHorizontal;
		Transform myTransform;
		Quaternion newRotation = Quaternion.identity;
		Compass supportedDirection;

		void Start ()
		{
				direction = Compass.North;
				myTransform = transform;
				//supportedDirection = GameManager.Instance.SupportedDirection;
				supportedDirection = Compass.South | Compass.North | Compass.East | Compass.West;
		
		}
			
		/// <summary>
		/// swipe the camera horizontally by 90 degree
		/// </summary>
		/// <param name="rollSwipeDirection">Roll swipe direction.</param>
		public void RollCamera (TKSwipeDirection rollSwipeDirection)
		{
				direction = direction.GetNextDirection (rollSwipeDirection, supportedDirection);
				float newAngle = 0f;
				newRotation = Quaternion.Euler (new Vector3 (myTransform.rotation.eulerAngles.x, direction.GetAngle (), myTransform.rotation.eulerAngles.z));

		}
		
		// Update is called once per frame
		void Update ()
		{
				if (myTransform.rotation.eulerAngles.y != newRotation.eulerAngles.y)
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation, newRotation, Time.deltaTime * 10f);

		}
}
