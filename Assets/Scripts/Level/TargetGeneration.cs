using UnityEngine;
using System.Collections;

public class TargetGeneration : MonoBehaviour {

	// Use this for initialization
	public Transform normalTarget;
	public Transform timeTarget;
	public Transform bombTarget;
	public Transform freezeTarget;
	
	public int targetSpeed = 500;
	public bool left;
	public int ID;
	
	void Start () {
		InvokeRepeating("targetMethod",1,1);
	}
	
	void targetMethod(){
		
		Targets targetID = Database.GetTarget(GameStatus.Level,GameStatus.Inst.Time,ID);
		if(targetID == Targets.Null)
			return;
		Transform t = null;
		if(targetID == Targets.NormalTarget)
			t = normalTarget;
		else if(targetID == Targets.TimeTarget)
			t = timeTarget;
		else if(targetID == Targets.BombTarget)
			t = bombTarget;
		else 
			t = freezeTarget;
		
		if(t != null){
			Transform targetInst = (Transform)Instantiate(t,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			if(left)
				targetInst.rigidbody.AddForce(Vector3.left*targetSpeed);	
			else
				targetInst.rigidbody.AddForce(Vector3.right*targetSpeed);
		}
	}
}
