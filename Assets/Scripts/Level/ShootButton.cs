using UnityEngine;
using System.Collections;

public class ShootButton : UIButton {

	void Start () {
		base.Start();
		inputDelegate = action;
	}
	
	void action(ref POINTER_INFO ptr)
	{
		if(!Character.Inst.CanShoot)
			return;
		if(Character.Inst.animation.IsPlaying("shoot")||Character.Inst.animation.IsPlaying("cut"))
			return;
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.TAP)
			Character.Inst.ShootArrow();
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE)
			Character.Inst.ShootArrow();
		if(ptr.evt == POINTER_INFO.INPUT_EVENT.RELEASE_OFF)
			Character.Inst.ShootArrow();
	}
	


	
}
