using UnityEngine;
using System.Collections;

public class FreezeTarget : Target {
	
	public static float FREEZETIME = 5.0f;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.FreezeTarget;
		
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
		createSound();
		Control control = FindObjectOfType(typeof(Control)) as Control;
		control.Freeze(FREEZETIME);
		Destroy(gameObject);
	}
}
