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
	
	public bool left;
	public int ID;
	
	void Start () {
		InvokeRepeating("targetMethod",0.1f,1);   //3 times a secs?
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
		
		if(t != null){
			Transform targetInst = (Transform)Instantiate(t,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			
			if(left)
				targetInst.rigidbody.AddForce(Vector3.left*Database.GetTargetSpeed(GameStatus.Level,GameStatus.Inst.TimeSpend,ID));	
			else
				targetInst.rigidbody.AddForce(Vector3.right*Database.GetTargetSpeed(GameStatus.Level,GameStatus.Inst.TimeSpend,ID));
		}
	}
}
