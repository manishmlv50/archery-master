using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	private int movefingerId = -1;
	
	public Texture2D downButton;
	public Texture2D upButton;
	public Transform shotPoint;
	public Transform fireBall;
	public int fireSpeed = 5000;
	
	public static bool run;
	
	// Use this for initialization
	void Start () {
		fireSpeed = 5000;
		run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!run)
			return;
		if(GameStatus.Inst.ArrowCount == 0)
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
				        	                                  Quaternion.LookRotation(Vector3.forward));
					bullet.rigidbody.AddForce(transform.forward*fireSpeed);
					ShootArrow();
				}
			}
			
			// click to shoot
			else {			
				if(currentTouch.phase == TouchPhase.Ended) {			
					Transform bullet = (Transform)Instantiate(fireBall,
					                                          shotPoint.transform.position,
					                                          Quaternion.LookRotation(Vector3.forward));
					bullet.rigidbody.AddForce(transform.forward*fireSpeed);
					ShootArrow();
					StartCoroutine("delay");
				}
			}
		}
		
		if(Input.GetButtonDown("Jump")){
			Transform bullet = (Transform)Instantiate(fireBall,
			                                          shotPoint.transform.position,
			                                          Quaternion.LookRotation(Vector3.forward));
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
			run = false;
			StartCoroutine("delay1");
		}
	}
}
