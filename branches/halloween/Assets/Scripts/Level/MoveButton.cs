using UnityEngine;
using System.Collections;

public class MoveButton : UIButton {

	// Use this for initialization
	
	private static bool press = false;
	private static int direction = 0;
	void Start () {
		base.Start();
		AddInputDelegate(action);
	}
	
	void action(ref POINTER_INFO ptr)
	{
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.PRESS){
			direction = getDragDirection(ptr.devicePos);
			press = true;
		}
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.DRAG && press) {
			direction = getDragDirection(ptr.devicePos);
		}
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP
		   ||ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE
		   ||ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE_OFF
		   ||ptr.evt == POINTER_INFO.INPUT_EVENT.MOVE
		   ||ptr.evt == POINTER_INFO.INPUT_EVENT.MOVE_OFF){
			direction = 0;
			press = false;
		}
		Character.Inst.MoveDirection = direction;
	}
	
	int getDragDirection(Vector3 touch)
	{
		Vector3 p = Camera.allCameras[1].WorldToScreenPoint(transform.position);
		if(touch.x - p.x > 10)
			return 1;
		else if(touch.x - p.x < -10)
			return -1;
		else
			return 0;
	}
}
