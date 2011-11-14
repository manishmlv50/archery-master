using UnityEngine;
using System.Collections;

public class ReadyGo : PackedSprite {
	
	public override void OnDestroy ()
	{
		base.OnDestroy ();
		if(Control.Inst != null)
			Control.Inst.begin();
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("TargetGen"))
		{
			TargetGeneration tg = go.GetComponent<TargetGeneration>();
			if(tg != null)
				tg.begin();
		}
		if(Character.Inst != null){
			Character.Inst.CanMove = true;
			Character.Inst.CanShoot = true;
		}
	}
}
