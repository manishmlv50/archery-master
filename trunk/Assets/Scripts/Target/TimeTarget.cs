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
		createExplosion();
		
		// Earn Score
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		
		// Access Time Target script attached to "TimeTarget"
		TimeTarget tt = gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
		tt.createSound();	// create destroy sound
		
		// Add 10 seconds to level time
		GameStatus.Inst.IncreaseTime(EXTRA_TIME);
		Destroy(gameObject);
	}
}
