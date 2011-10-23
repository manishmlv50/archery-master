using UnityEngine;
using System.Collections;

public class ReflectorWall : Target {

	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.ReflectorTarget;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	override public void DoEffect(Arrow arrow)
	{
		createSound();
		arrow.rigidbody.AddForce(-arrow.transform.forward * 7000);
	}
}
