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
		if(effected )
			return;
		effected = true;
		createSound();
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
		if(e != null)
			e.addEnergy(20);
		Destroy(this.gameObject);
	}
}


