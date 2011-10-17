using UnityEngine;
using System.Collections;

public class StrongTarget : Target {
	
	public int hit_points = 50;
	public Material secondMaterial;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.StrongTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	override public void DoEffect(Arrow arrow)
	{
		/* Decrease hit points */
		hit_points = hit_points - Arrow.DMG_AMOUNT;
		
		if(hit_points <= 0){
			createExplosion();
			createSound();
			// Earn Score for destroying the Bomb Target
			GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
			Destroy(gameObject);
		}
		else if(hit_points < 50 && hit_points > 0){
			renderer.material = secondMaterial;	
		}
		
		Destroy(arrow.gameObject);
	}
}
