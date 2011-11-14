using UnityEngine;
using System.Collections;

public class WallTarget : Target {
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.WallTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	override public void DoEffect(Arrow arrow)	{
		createExplosion();
		createSound();
		
		/* Don't Destroy the Wall Target, destroy the arrow */
		Destroy(arrow.gameObject);
		
		if(arrow.rigidbody.velocity.z < 0) {
			Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
			if(e != null) e.addEnergy(20);
			recycle();
		}
	}
}
