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
		if(effected )
			return;
		effected = true;
		// Dim the lights to create a dark scene
		LightControl l = GameObject.FindObjectOfType(typeof(LightControl)) as LightControl;
		l.TurnDark();
		createExplosion();
		
		createSound();		
		recycle();
		Destroy(arrow.gameObject);
	}
	
	
}
