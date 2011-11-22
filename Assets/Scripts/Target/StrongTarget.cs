using UnityEngine;
using System.Collections;

public class StrongTarget : Target {
	
	public int hit_points = 50;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.StrongTarget;
	}
	
	override public void Resume()
	{
		PackedSprite ps = GetComponent<PackedSprite>();
		if(ps != null)
			ps.PlayAnim(0);
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
			PackedSprite ps = GetComponent<PackedSprite>();
			if(ps != null)
				ps.PlayAnim(1);
			Destroy(arrow.gameObject);
		}		
	}
}
