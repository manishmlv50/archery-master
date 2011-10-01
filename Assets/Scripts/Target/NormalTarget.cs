using UnityEngine;
using System.Collections;

public class NormalTarget  : Target
{
	public void Start ()
	{
		TARGET_ID = Targets.NormalTarget;
	}
	
	override public void DoEffect(Arrow arrow)
	{
		createSound();
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		Destroy(this.gameObject);
	}
}


