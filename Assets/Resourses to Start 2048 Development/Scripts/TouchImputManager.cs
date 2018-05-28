using UnityEngine;
using System.Collections;

public class TouchImputManager : MonoBehaviour 
{


	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDistance = 50.0f;
	private float maxSwipeTime = 1.5f;

	private GameManager gm;

	void Awake () 
	{
		gm = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gm.State == GameState.Playing && Input.touchCount > 0) 
		{
			foreach (Touch touch in Input.touches) 
			{
				switch (touch.phase) 
				{
				case TouchPhase.Began:
					//this is a new touch
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled:
					//the touch is being cancelled
					isSwipe = false;
					break;

				case TouchPhase.Ended:
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDistance) {
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) { 
							//the swipe is horizontal
							swipeType = Vector2.right * Mathf.Sign (direction.x);
						} else {
							//the swipe is vertical
							swipeType = Vector2.up * Mathf.Sign (direction.y);
						}
						if (swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f) {
								//MOVE RIGHT
								gm.Move (InputManager.MoveDirection.Right);
							} else {
								//MOVE LEFT
								gm.Move (InputManager.MoveDirection.Left);
							}
						}
						if (swipeType.y != 0.0f) {
							if (swipeType.y > 0.0f) {
								//MOVE UP
								gm.Move (InputManager.MoveDirection.Up);
							} else {
								//MOVE DOWN
								gm.Move (InputManager.MoveDirection.Down);
							}
						}
					}
					break;
				}
			}
		}
	}
}
