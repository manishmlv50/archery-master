using UnityEngine;
using System.Collections;

public class DarknessTarget : Target {
	
	// Use this for initialization
	public static int DARK_TIME = 5;
	void Start () {
		TARGET_ID = Targets.DarknessTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	override public void DoEffect(Arrow arrow)
	{	
		// Dim the lights to create a dark scene
		LightGroup l = GameObject.FindObjectOfType(typeof(LightGroup)) as LightGroup;
		l.Intensity = 0.1f;
		createExplosion();
		createSound();
		
		Destroy(gameObject);
		Destroy(arrow.gameObject);
	}
	
	
}
