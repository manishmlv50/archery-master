using UnityEngine;
using System.Collections;

public class StrongTarget : Target {
	
	public int hit_points = 50;
	public Material secondMaterial;
	public Material firstMaterial;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.StrongTarget;
	}
	
	override public void Resume()
	{
		renderer.material = firstMaterial;	
		effected = false;
		hit_points = 50;
	}
	
	override public void DoEffect(Arrow arrow)
	{
		/* Decrease hit points */
		hit_points = hit_points - Arrow.DMG_AMOUNT;
		
		if(hit_points <= 0){
			if(effected )
				return;
			effected = true;
			createExplosion();
			createSound();
			// Earn Score for destroying the Strong Target
			GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
			Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
			if(e != null)
				e.addEnergy(40);
			recycle();
		}
		else if(hit_points < 50 && hit_points > 0){
			renderer.material = secondMaterial;	
			Destroy(arrow.gameObject);
		}		
	}
}
