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
		Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
		if(e != null)
			e.addEnergy(20);
		
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		
		TimeTarget tt = gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
		tt.createSound();
		
		GameStatus.Inst.IncreaseTime(EXTRA_TIME);
		recycle();
	}
}
