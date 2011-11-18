using UnityEngine;
using System.Collections;

public class MoveButton : UIButton {

	// Use this for initialization
	public bool left;
	
	void Start () {
		base.Start();
		inputDelegate = action;
	}
	
	void action(ref POINTER_INFO ptr)
	{
		if(!Character.Inst.CanMove)
			return;
		if(left){
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.PRESS)
				Character.Inst.MoveDirection = -1;
				
			float x = ptr.origPos.x;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.DRAG) {
				if((ptr.devicePos.x - x) <= 0)
					Character.Inst.MoveDirection = -1;
				else
					Character.Inst.MoveDirection = 1;
			}
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
				Character.Inst.MoveDirection = 0;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE)
				Character.Inst.MoveDirection = 0;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE_OFF)
				Character.Inst.MoveDirection = 0;
		}
		else
		{
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.PRESS)
				Character.Inst.MoveDirection = 1;
			
			float x = ptr.origPos.x;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.DRAG) {
				if((ptr.devicePos.x - x) >= 0)
					Character.Inst.MoveDirection = 1;
				else
					Character.Inst.MoveDirection = -1;
			}
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
				Character.Inst.MoveDirection = 0;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE)
				Character.Inst.MoveDirection = 0;
			if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE_OFF)
				Character.Inst.MoveDirection = 0;
		}
	}
	
	
}
