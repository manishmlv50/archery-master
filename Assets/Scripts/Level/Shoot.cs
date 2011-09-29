using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	private int movefingerId = -1;
	
	public Texture2D downButton;
	public Texture2D upButton;
	public Transform shotPoint;
	public Transform fireBall;
	public int fireSpeed = 1000;
	
	public static bool run;
	public static float dragRange = 0;
	
	private float preY = 0;
	
	// Use this for initialization
	void Start () {
		run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!run)
			return;
		
		foreach(Touch currentTouch in Input.touches){
			// Virtual fire button
			if(GameStatus.ctrl) {
				if(currentTouch.phase == TouchPhase.Began && guiTexture.HitTest(currentTouch.position)){
					guiTexture.texture = downButton;
					movefingerId = currentTouch.fingerId;
				}
		
				else if(currentTouch.phase == TouchPhase.Ended && currentTouch.fingerId == movefingerId){
					guiTexture.texture = upButton;
					StartCoroutine("delay");
					movefingerId = -1;
					Transform bullet = (Transform)Instantiate(fireBall,
				    	                                      shotPoint.transform.position,
				        	                                  Quaternion.LookRotation(new Vector3(0,270,90)));
					bullet.rigidbody.AddForce(transform.forward*fireSpeed);
					ShootArrow();
				}
			}
			
			// Drag
			else {
				if(currentTouch.phase == TouchPhase.Began) {
					preY = currentTouch.position.y;
				}
			
				if(currentTouch.phase == TouchPhase.Moved) {
					float y = currentTouch.position.y;
					dragRange = Mathf.Abs(y - preY);
				
					if(dragRange >= 0.5*Screen.height) dragRange = 5;
					else if(dragRange >= 0.4*Screen.height) dragRange = 4;
					else if(dragRange >= 0.3*Screen.height) dragRange = 3;
					else if(dragRange >= 0.2*Screen.height) dragRange = 2;
					else dragRange = 1;
				}
			
				if(currentTouch.phase == TouchPhase.Ended) {			
					fireSpeed = (int) dragRange * 1500;
					Transform bullet = (Transform)Instantiate(fireBall,
					                                          shotPoint.transform.position,
					                                          Quaternion.LookRotation(new Vector3(0,270,90)));
					bullet.rigidbody.AddForce(transform.forward*fireSpeed);
					ShootArrow();
					StartCoroutine("delay");
				}
			}
		}
		
		if(Input.GetButtonDown("Jump")){
			Transform bullet = (Transform)Instantiate(fireBall,
			                                          shotPoint.transform.position,
			                                          Quaternion.LookRotation(new Vector3(0,270,90)));
			bullet.rigidbody.AddForce(transform.forward*fireSpeed);
			ShootArrow();
			StartCoroutine("delay");
			
		}
	}
	
	IEnumerator delay() {
		run = false;
		yield return new WaitForSeconds(0.25f);
		run = true;
	}
	
	IEnumerator delay1() {
		run = false;
		yield return new WaitForSeconds(1f);
		if(GameStatus.Inst.Score >= GameStatus.Inst.TargetScore){
				Application.LoadLevel("Statistic");
			}
			else{
				Application.LoadLevel("GameOver");
			}
	}
	
	public void ShootArrow(){
		GameStatus.Inst.ArrowCount -- ;
		if(GameStatus.Inst.ArrowCount == 0)
		{
			StartCoroutine("delay1");
			
		}
	}
}
