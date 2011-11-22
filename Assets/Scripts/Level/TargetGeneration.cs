using UnityEngine;
using System.Collections;

public class TargetGeneration : MonoBehaviour {

	// Use this for initialization
	public Transform normalTarget;
	public Transform timeTarget;
	public Transform bombTarget;
	public Transform freezeTarget;
	public Transform projectileTarget;
	public Transform wallTarget;
	public Transform strongTarget;
	public Transform darknessTarget;
	public Transform reflectorTarget;
	
	public bool left;
	public int ID;
	private int defaultSpeed = 500;
	
	void Start () {
		if(GameStatus.Level >= 7 && ID == 0) {
			Transform mirror1 = (Transform)Instantiate(reflectorTarget,
			                                              new Vector3(20,10,57),
			                                              Quaternion.identity);
			Transform mirror2 = (Transform)Instantiate(reflectorTarget,
			                                              new Vector3(-20,10,57),
			                                              Quaternion.identity);
		}
	}
	
	public void begin()
	{
		InvokeRepeating("targetMethod",0.2f,1);
	}
	
	public void end()
	{
		CancelInvoke("targetMethod");
	}
	
	void targetMethod(){
		
		Targets targetID = Database.GetTarget(GameStatus.Level,GameStatus.Inst.TimeSpend,ID);
		if(targetID == Targets.Null)
			return;
		Transform t = null;
		if(targetID == Targets.NormalTarget)
			t = normalTarget;
		else if(targetID == Targets.TimeTarget)
			t = timeTarget;
		else if(targetID == Targets.BombTarget)
			t = bombTarget;
		else if(targetID == Targets.FreezeTarget)
			t = freezeTarget;
		else if(targetID == Targets.ProjectileTarget)
			t = projectileTarget;
		else if(targetID == Targets.WallTarget)
			t = wallTarget;
		else if(targetID == Targets.StrongTarget)
			t = strongTarget;
		else if(targetID == Targets.DarknessTarget)
			t = darknessTarget;
		else if(targetID == Targets.ReflectorTarget)
			t = reflectorTarget;
		
		if(t != null){
			
			int speed = Database.GetTargetSpeed(GameStatus.Level,GameStatus.Inst.TimeSpend,ID);
			if(speed == 0){
				Debug.LogWarning("Warning! Please check the LevelsSpeed File. Level:"+GameStatus.Level+" Time:"+GameStatus.Inst.TimeSpend+" Id:"+ID);
				speed = defaultSpeed;
			}
			Target.allocateTarget(targetID,t,transform.position,left,speed);
		}
	}
}
