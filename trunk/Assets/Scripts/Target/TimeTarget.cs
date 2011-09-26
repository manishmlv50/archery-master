using UnityEngine;
using System.Collections;

public class TimeTarget : Target{
	
	public static int EXTRA_TIME = 10;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.TimeTarget;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	override public void DoEffect(Arrow arrow)
	{
		// Access Detonator script attached to "TimeTarget"
		Detonator d = gameObject.GetComponent(typeof(Detonator)) as Detonator; 
		d.Explode(); // start destroy animation
		
		// Earn Score
		GameStatus.Inst.EarnScore(arrow.Counter++, TARGET_ID);
		
		// Access Time Target script attached to "TimeTarget"
		TimeTarget tt = gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
		tt.createSound();	// create destroy sound
		d.renderer.enabled = false; // hide time target object
		
		// Add 10 seconds to level time
		GameStatus.Inst.Time += EXTRA_TIME;
		Destroy(this.gameObject);
	}
}
