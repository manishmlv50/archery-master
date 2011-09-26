using UnityEngine;
using System.Collections;

public class NormalTarget  : Target
{
	public Transform explosion;

	public void Start ()
	{
		TARGET_ID = Targets.NormalTarget;
	}
	
	override public void DoEffect(Arrow arrow)
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		createSound();
		GameStatus.Inst.EarnScore(arrow.Counter++, TARGET_ID);
		Destroy(this.gameObject);
	}
}


