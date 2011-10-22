using UnityEngine;
using System.Collections;

public class BombTarget : Target {
	
	public int damage_radius = 25;
	
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
		createExplosion();
		createSound();
		
		// Earn Score for destroying the Bomb Target
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		
		// Find game objects of NormalTarget type
		Object[] gos = GameObject.FindObjectsOfType(typeof(NormalTarget));
		foreach(Object go in gos)
		{
			NormalTarget t = go as NormalTarget;
			
			// Check if the distance of the "BombTarget" and this "Target" is less than the damage_radius
			if(t!=null && Vector3.Distance(gameObject.transform.position,
			                     t.transform.position) < damage_radius)
			{
				t.DoEffect(arrow);
			}
		}
		Destroy(arrow.gameObject);
		Destroy(gameObject);
	}
}
