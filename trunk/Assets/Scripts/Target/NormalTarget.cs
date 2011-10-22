using UnityEngine;
using System.Collections;

public class NormalTarget  : Target
{
	public void Start ()
	{
		TARGET_ID = Targets.NormalTarget;
		this.missPunish = 1;
	}
	
	override public void DoEffect(Arrow arrow)
	{
		createSound();
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
		if(e != null)
			e.addEnergy(20);
		Destroy(this.gameObject);
	}
}


