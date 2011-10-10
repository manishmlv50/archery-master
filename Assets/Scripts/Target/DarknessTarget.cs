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
		// Dim the lights to create a dark scene
		Object[] os = GameObject.FindObjectsOfType(typeof(Light));
		foreach(Object o in os){
			Light light = (Light) o;
			light.intensity = 0.1f;
		}
		
		createExplosion();
		createSound();
		
		Destroy(gameObject);
		Destroy(arrow.gameObject);
	}
}
