using UnityEngine;
using System.Collections;

/* This target will add an X amount to the current weapon's ammo count */

public class ProjectileTarget : Target {
	
	public int EXTRA_AMMO = 5;
	
	void Start () {
		TARGET_ID = Targets.ProjectileTarget;
	}
	
	void Update(){
		
	}
	
	override public void DoEffect(Arrow arrow)
	{
		if(effected )
			return;
		effected = true;
		createExplosion();
		createSound();
		
		// Add extra ammo for destroying this target
		GameStatus.Inst.ArrowCount += EXTRA_AMMO; //EarnScore(arrow.Combo++, TARGET_ID);
		
		Destroy(gameObject);
	}
}
