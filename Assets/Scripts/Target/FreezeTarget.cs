using UnityEngine;
using System.Collections;

public class FreezeTarget : Target {
	
	public static bool isFrozen = false;
	public static float FREEZETIME = 5.0f; // 10 seconds
	public static float lastTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.FreezeTarget;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	override public void DoEffect(Arrow arrow)
	{
		
		
		this.createExplosion();
		// Access Freeze Target script attached to "FreezeTarget"
		createSound();	// create destroy sound
		
		FreezeTarget.lastTime = Time.time;
		FreezeTarget.isFrozen = true;
		Destroy(gameObject);
	}
}
