using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
	public static Control Inst {get;set;}
	
	void Start ()
	{
		Target.clearPool();
		Inst = this;
	}
	
	public void begin()
	{
		InvokeRepeating ("countDown", 0.5f, 1);
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
		
		#if UNITY_EDITOR
		if (Input.GetButton ("Horizontal")) {
			if (Input.GetAxis ("Horizontal") > 0) {
				Character.Inst.MoveDirection = 1;
			} else if (Input.GetAxis ("Horizontal") < 0) {
				Character.Inst.MoveDirection = -1;
			}
		} else if (Input.GetButtonUp ("Horizontal")) {
			Character.Inst.MoveDirection = 0;
		}
		
		if (Input.GetButtonDown ("Jump")) {
			Character.Inst.ShootArrow ();
		}
		#endif
	}
	
	void countDown ()
	{
		GameStatus.Inst.Time--;
	}
}
