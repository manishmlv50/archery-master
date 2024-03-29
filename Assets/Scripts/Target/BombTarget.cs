using UnityEngine;
using System.Collections;

public class BombTarget : Target {
	
	public int damage_radius = 25;
	
	// Use this for initialization
	void Start () {
		TARGET_ID = Targets.BombTarget;
	}
	
	override public void DoEffect(Arrow arrow)
	{
		if(effected )
			return;
		effected = true;
		createExplosion();
		createSound();
		Energy e = GameObject.FindObjectOfType(typeof(Energy)) as Energy;
		if(e != null)
			e.addEnergy(20);
		
		// Earn Score for destroying the Bomb Target
		GameStatus.Inst.EarnScore(arrow.Combo++, TARGET_ID);
		
		// Find game objects of NormalTarget type
		// Check if the distance of the "BombTarget" and this "Target" is less than the damage_radius
		
		Object[] gos = GameObject.FindObjectsOfType(typeof(Target));
		foreach(Object go in gos) {
			Target t = go as Target;
			if(t.gameObject.active == false)
				continue;
			if(t is WallTarget){
				continue;
			}
			
			if(Vector3.Distance(gameObject.transform.position, t.transform.position) < damage_radius) {
				StrongTarget s = t as StrongTarget;
				if(s != null)
					s.hit_points = -1;
				
				t.DoEffect(arrow);
			}
		}
		Destroy(arrow.gameObject);
		recycle();
	}
}
