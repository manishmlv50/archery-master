using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	private int movefingerId = -1;
	
	public Texture2D downButton;
	public Texture2D upButton;
	public Transform shotPoint;
	public Transform fireBall;
	public int fireSpeed = 1000;
	
	private bool run;
	
	// Use this for initialization
	void Start () {
		run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!run)
			return ;
		foreach(Touch currentTouch in Input.touches){
			if(currentTouch.phase == TouchPhase.Began && guiTexture.HitTest(currentTouch.position)){
				guiTexture.texture = downButton;
				movefingerId = currentTouch.fingerId;				
		}
		
			else if(currentTouch.phase == TouchPhase.Ended && currentTouch.fingerId == movefingerId){
				guiTexture.texture = upButton;
				StartCoroutine("delay");
				movefingerId = -1;
				Transform bullet = (Transform)Instantiate(fireBall,shotPoint.transform.position,Quaternion.LookRotation(new Vector3(0,270,90)));
				bullet.rigidbody.AddForce(transform.forward*fireSpeed);
				ShootArrow();
			}
		}
		
		if(Input.GetButtonDown("Jump")){
			Transform bullet = (Transform)Instantiate(fireBall,shotPoint.transform.position,Quaternion.LookRotation(new Vector3(0,270,90)));
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
			StartCoroutine("delay1");
			
		}
	}
}
