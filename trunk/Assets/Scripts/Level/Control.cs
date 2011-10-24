using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{

	private Character character;
	private bool canShoot;
	private bool canMove;
	private Vector2 position;
	private int finger;

	public int fireSpeed = 5000;
	public Transform shotPoint;
	public Transform [] arrows;
	
	

	void Start ()
	{
		position = Vector2.zero;
		canShoot = true;
		canMove = true;
		finger = int.MinValue;
		character = GameObject.FindObjectOfType (typeof(Character)) as Character;
		new GameStatus (
		                Database.GetTime (GameStatus.Level), 
		                Database.GetTargetScore (GameStatus.Level), 
		                Database.GetArrowCount (GameStatus.Level), 
		                Database.GetMoveSpeed (), 
		                Database.GetScoreBonus (), 
		                Database.GetComboBonus (), 
		                Database.GetHP(GameStatus.Level));
		
		
		InvokeRepeating ("countDown", 1, 1);
	}

	// Update is called once per frame
	void Update ()
	{			
		if (GameStatus.tilting) {
			character.MoveDirection = -Input.acceleration.y * 6f;
			character.MoveDirection = Mathf.Clamp (character.MoveDirection, -1, 1);
		}
		
		foreach (Touch currentTouch in Input.touches) {
			if (currentTouch.phase == TouchPhase.Ended || currentTouch.phase == TouchPhase.Canceled) {
				if (currentTouch.fingerId != finger && canShoot){
					ShootArrow ();
				}
				else{
					character.MoveDirection = 0;
					finger = int.MinValue;
				}
			}
			else if(finger == currentTouch.fingerId && currentTouch.phase == TouchPhase.Stationary)
			{
				if(canMove && canShoot){
					if (currentTouch.position.x > position.x)
						character.MoveDirection = 1;
					else
						character.MoveDirection = -1;
				}
			}
			else if (currentTouch.phase == TouchPhase.Moved) {
				if(finger == int.MinValue)
				{
					position = currentTouch.position - currentTouch.deltaPosition;
					finger = currentTouch.fingerId;
				}
				if(canMove && canShoot){
					if (currentTouch.position.x > position.x)
						character.MoveDirection = 1;
					else
						character.MoveDirection = -1;
				}
			}
		}
		
		
		
		#if UNITY_EDITOR
		if (Input.GetButton ("Horizontal") && canMove && canShoot) {
			if (Input.GetAxis ("Horizontal") > 0) {
				character.MoveDirection = 1;
			} else if (Input.GetAxis ("Horizontal") < 0) {
				character.MoveDirection = -1;
			}
		} else if (Input.GetButtonUp ("Horizontal")) {
			character.MoveDirection = 0;
		}
		
		if (Input.GetButtonDown ("Jump") && canShoot) {
			ShootArrow ();
		}
		#endif
	}
	
	public void Freeze(float time)
	{
		character.MoveDirection = 0;
		canMove = false;
		Invoke("enableMove",time);
	}
		
	void enableMove()
	{
		canMove = true;
	}

	public void ShootArrow ()
	{
		canShoot = false;
		character.MoveDirection = 0;
		character.animation.CrossFade("shoot");
		Invoke ("doShoot", 0.2f);
	}
	
	void endLevel ()
	{
		if (GameStatus.Inst.ArrowCount > 0) {
			canShoot = true;
		} else {
			if (GameStatus.Inst.Score >= GameStatus.Inst.TargetScore) {
				Application.LoadLevel ("Statistic");
			} else {
				Application.LoadLevel ("GameOver");
			}
		}
	}

	void doShoot ()
	{
		Transform bullet = (Transform)Instantiate (arrows[(int)GameStatus.Inst.Arrow], shotPoint.transform.position, Quaternion.LookRotation (Vector3.forward));
		bullet.rigidbody.AddForce (transform.forward * fireSpeed);
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e == null || !e.super_mode)
			GameStatus.Inst.ArrowCount--;
		if (GameStatus.Inst.ArrowCount == 0)
			Invoke ("endLevel", 0.5f);
		else
			Invoke ("enableShoot", 0.4f);
	}
	
	void enableShoot ()
	{
		canShoot = true;
	}

	void countDown ()
	{
		if (GameStatus.Inst.Time == 0) {
			if (GameStatus.Inst.Score >= GameStatus.Inst.TargetScore) {
				Application.LoadLevel ("Statistic");
			} else {
				Application.LoadLevel ("GameOver");
			}
		} else {
			GameStatus.Inst.Tick ();
		}
	}	
}
