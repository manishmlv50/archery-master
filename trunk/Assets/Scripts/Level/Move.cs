using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	// Use this for initialization
	public Texture2D downButton;
	public Texture2D upButton;
	public GUITexture moveStick;
	
	private int movefingerId = -1;
	private float center = 1;
	private float left = 1;
	private float right = 1;
	
	public static float moveDirection = 0;
	
	void Start () {
		moveDirection = 0;
		center = guiTexture.pixelInset.x;
		left = moveStick.pixelInset.x - guiTexture.pixelInset.width/2;
		right = moveStick.pixelInset.x + moveStick.pixelInset.width - guiTexture.pixelInset.width/2;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!Shoot.run) {
			moveDirection = 0;
			return;
		}
		
		if(GameStatus.ctrl) {
			// Virtual stick control
			foreach(Touch currentTouch in Input.touches){
				if(currentTouch.phase == TouchPhase.Began && guiTexture.HitTest(currentTouch.position)){
					guiTexture.texture = downButton;
					movefingerId = currentTouch.fingerId;
				}
			
				else if(currentTouch.phase == TouchPhase.Ended && currentTouch.fingerId == movefingerId){
					guiTexture.texture = upButton;
					guiTexture.pixelInset = new Rect(center,guiTexture.pixelInset.y,guiTexture.pixelInset.width,guiTexture.pixelInset.height);
					movefingerId = -1;
					moveDirection = 0;
				}
			
				else if(currentTouch.phase == TouchPhase.Moved && currentTouch.fingerId == movefingerId){
					float x = 0;
					float touchX = currentTouch.position.x - guiTexture.pixelInset.width/2;
					if(touchX > center){
						x = Mathf.Min(touchX,right);
						if(x - center > guiTexture.pixelInset.width/5)
							moveDirection = 1;
						else
							moveDirection = 0;
					}
					else{
						x = Mathf.Max(left,touchX);
						if(center - x > guiTexture.pixelInset.width/5)
							moveDirection = -1;
						else
							moveDirection = 0;
					}
					guiTexture.pixelInset = new Rect(x,guiTexture.pixelInset.y,guiTexture.pixelInset.width,guiTexture.pixelInset.height);
				}
			}
		}
		// Tilting
		else{
			moveDirection = -Input.acceleration.y * 4f;
		}
		
		// Keyboard Control
		if(Input.GetButton("Horizontal")) {
			if(Input.GetAxis("Horizontal") > 0 ) {
				moveDirection = 1;
			}
			else if(Input.GetAxis("Horizontal") < 0) {
				moveDirection = -1;
			}
		}
		else if(Input.GetButtonUp("Horizontal")){
			moveDirection = 0;
		}
	}
}
