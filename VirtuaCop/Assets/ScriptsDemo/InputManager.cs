using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{			
		TKTapRecognizer tapGesture;
		TKSwipeRecognizer swipeHorizontal;
		TKLongPressRecognizer longPress;
		Transform playerOffset;

		RaycastHit shootHit;
		Ray shootRays;
		PlayerAim playerAimAt;
		RollAndYawFrame rollAndYawFrame;
		int nonShootablelayerMask;
		// Use this for initialization

		void Awake ()
		{
				//Swipe
				swipeHorizontal = new TKSwipeRecognizer (TKSwipeDirection.Horizontal);
				swipeHorizontal.gestureRecognizedEvent += HorizontalSwipe;		
				TouchKit.addGestureRecognizer (swipeHorizontal);

				//tap
				tapGesture = new TKTapRecognizer ();
				tapGesture.gestureRecognizedEvent += Tapped;
				TouchKit.addGestureRecognizer (tapGesture);
			
				//long press
				longPress = new TKLongPressRecognizer ();
				longPress.gestureRecognizedEvent += LongPressStarted;
				longPress.gestureCompleteEvent += LongPressEnded;
				TouchKit.addGestureRecognizer (longPress);

				playerOffset = GameObject.FindGameObjectWithTag (Constants.PLAYER_OFFSET_TAG).transform;
				playerAimAt = playerOffset.GetComponent<PlayerAim> ();							
		
				rollAndYawFrame = GameObject.FindGameObjectWithTag (Constants.PLAYER_CAMERA_COMPOSITE_TAG).GetComponent<RollAndYawFrame> ();
							
				nonShootablelayerMask = ~(1 << 9);
		}
	
		void Destroy ()
		{
				longPress.gestureRecognizedEvent -= LongPressStarted;
				longPress.gestureCompleteEvent -= LongPressEnded;
		}

		void Tapped (TKTapRecognizer tapParam)
		{				
				shootRays = Camera.main.ScreenPointToRay (tapParam.touchLocation ());
				if (Physics.Raycast (shootRays, out shootHit, 100f, nonShootablelayerMask)) {							
						playerAimAt.AimAt (shootHit.point);
				}		
		}

		void HorizontalSwipe (TKSwipeRecognizer swipeParam)
		{
				//swipe the camera by 90 degree horizontally
				rollAndYawFrame.RollCamera (swipeParam.completedSwipeDirection);				
		}

		void LongPressStarted (TKLongPressRecognizer startParam)
		{
				Debug.Log ("longPressStart");
		}

		void LongPressEnded (TKLongPressRecognizer endParam)
		{
				Debug.Log ("longPressEnd");
		}
}
