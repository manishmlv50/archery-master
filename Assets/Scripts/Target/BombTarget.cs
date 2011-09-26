using UnityEngine;
using System.Collections;

public class BombTarget : Target {
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.BombTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	override public void DoEffect(Arrow arrow)
	{
		
		// Access Detonator script attached to "BombTarget"
		//Detonator d = gameObject.GetComponent(typeof(Detonator)) as Detonator; 
		//d.Explode(); // start destroy animation
		
		// Access Bomb Target script attached to "BombTarget"
		createSound();	// create destroy sound
		
		//d.renderer.enabled = false; // hide bomb target object
		
		// Earn Score for destroying the Bomb Target
		GameStatus.Inst.EarnScore(arrow.Counter++, TARGET_ID);
		
		// Find game objects with tag "Target"... this is for "Normal" targets
		Object[] gos = GameObject.FindObjectsOfType(typeof(NormalTarget));
		foreach(Object go in gos)
		{
			NormalTarget t = go as NormalTarget;
			// Check if the distance of the "BombTarget" and this "Target" is less than 25
			if(t!=null&&Vector3.Distance(gameObject.transform.position,
			                     t.transform.position) < 25)
			{
				// Destroy this object because it is within the distance threshold
				t.DoEffect(arrow);
			}
		}
		
		Destroy(this.gameObject);
	}
}
