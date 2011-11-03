using UnityEngine;
using System.Collections;

public class TimeTarget : Target{
	
	public static int EXTRA_TIME = 5;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.TimeTarget;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	override public void DoEffect(Arrow arrow)
	{
		if(effected )
			return;
		effected = true;
		createExplosion();
		
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		
		TimeTarget tt = gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
		tt.createSound();
		
		GameStatus.Inst.IncreaseTime(EXTRA_TIME);
		recycle();
	}
}
