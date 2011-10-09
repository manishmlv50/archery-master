using UnityEngine;
using System.Collections;

public class DarknessTarget : Target {
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.DarknessTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	override public void DoEffect(Arrow arrow)
	{	
		createExplosion();
		createSound();
		
		Destroy(gameObject);
		Destroy(arrow.gameObject);
	}
}
