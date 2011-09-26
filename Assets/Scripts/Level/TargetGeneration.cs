using UnityEngine;
using System.Collections;

public class TargetGeneration : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public int targetSpeed = 500;
	public bool left;
	public int ID;
	public ArrayList ts;
	
	void Start () {
		InvokeRepeating("targetMethod",1,1);
	}
	
	void targetMethod(){
		if(left){
			int targetID = Database.GetTarget(GameStatus.Level,GameStatus.Inst.Time,ID);
			Transform targetInst = null;
			if(targetID == -1)
				return;
			
			else if(targetID == 0)
				targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			else if(targetID == 1)
				targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			else if(targetID == 2)
				targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			else if(targetID == 3)
				targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));

			
			targetInst.rigidbody.AddForce(Vector3.left*targetSpeed);
		}
		
		else{
			Transform targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			targetInst.rigidbody.AddForce(Vector3.right*targetSpeed);
		}
	}
}
