using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
	private bool canMove;
	private Vector2 position;
	private int finger;

	public int fireSpeed = 5000;
	public Transform shotPoint;
	public Transform normalArrow;
	public Transform superArrow;
	
	

	void Start ()
	{
		Target.clearPool();
		position = Vector2.zero;
		canMove = true;
		finger = int.MinValue; 
		InvokeRepeating ("countDown", 1, 1);
	}

	// Update is called once per frame
	void Update ()
	{	
		if(Character.Inst.animation.IsPlaying("shoot")||Character.Inst.animation.IsPlaying("cut"))
			return;
		
		if (GameStatus.tilting) {
			Character.Inst.MoveDirection = -Input.acceleration.y * 6f;
			Character.Inst.MoveDirection = Mathf.Clamp (Character.Inst.MoveDirection, -1, 1);
		}
		
		else{
		foreach (Touch currentTouch in Input.touches) {
			if (currentTouch.phase == TouchPhase.Ended || currentTouch.phase == TouchPhase.Canceled) {
				if (currentTouch.fingerId != finger){
					ShootArrow ();
				}
				else{
					Character.Inst.MoveDirection = 0;
					finger = int.MinValue;
				}
			}
			else if(finger == currentTouch.fingerId && currentTouch.phase == TouchPhase.Stationary)
			{
				if(canMove){
					if (currentTouch.position.x > position.x)
						Character.Inst.MoveDirection = 1;
					else
						Character.Inst.MoveDirection = -1;
				}
			}
			else if (currentTouch.phase == TouchPhase.Moved) {
				if(finger == int.MinValue)
				{
					position = currentTouch.position - currentTouch.deltaPosition;
					finger = currentTouch.fingerId;
				}
				if(canMove){
					if (currentTouch.position.x > position.x)
						Character.Inst.MoveDirection = 1;
					else
						Character.Inst.MoveDirection = -1;
				}
			}
		}
		}
		
		
		
		#if UNITY_EDITOR
		if (Input.GetButton ("Horizontal") && canMove) {
			if (Input.GetAxis ("Horizontal") > 0) {
				Character.Inst.MoveDirection = 1;
			} else if (Input.GetAxis ("Horizontal") < 0) {
				Character.Inst.MoveDirection = -1;
			}
		} else if (Input.GetButtonUp ("Horizontal")) {
			Character.Inst.MoveDirection = 0;
		}
		
		if (Input.GetButtonDown ("Jump")) {
			ShootArrow ();
		}
		#endif
	}
	
	public void Freeze(float time)
	{
		Character.Inst.MoveDirection = 0;
		canMove = false;
		Invoke("enableMove",time);
	}
		
	void enableMove()
	{
		canMove = true;
	}

	public void ShootArrow ()
	{
		Character.Inst.MoveDirection = 0;
		if(!Character.Inst.Super)
		{	
			Character.Inst.animation.CrossFade("shoot");
			Invoke ("doNormalShoot", 0.25f);
		}
		else
		{
			Character.Inst.animation.CrossFade("cut");
			Invoke ("doSuperShoot", 0.1f);
		}
	}

	void doNormalShoot ()
	{
		Transform bullet = (Transform)Instantiate (normalArrow, shotPoint.transform.position, Quaternion.LookRotation (Vector3.forward));
		bullet.rigidbody.AddForce (transform.forward * fireSpeed);
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e == null || !Character.Inst.Super)
			GameStatus.Inst.ArrowCount--;
	}
	
	void doSuperShoot ()
	{
		Transform bullet = (Transform)Instantiate (superArrow, shotPoint.transform.position, Quaternion.LookRotation (Vector3.forward));
		bullet.rigidbody.AddForce (transform.forward * fireSpeed);
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e == null || !Character.Inst.Super)
			GameStatus.Inst.ArrowCount--;
	}

	void countDown ()
	{
		GameStatus.Inst.Time--;
	}	
}
