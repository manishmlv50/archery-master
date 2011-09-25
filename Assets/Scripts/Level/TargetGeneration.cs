using UnityEngine;
using System.Collections;

public class TargetGeneration : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public int targetSpeed = 500;
	public float interval;
	public bool left;
	
	void Start () {
		InvokeRepeating("targetMethod",1,interval);
	}
	
	void targetMethod(){
		if(left){
			Transform targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			targetInst.rigidbody.AddForce(Vector3.left*targetSpeed);
		}
		
		else{
			Transform targetInst = (Transform)Instantiate(target,transform.position,Quaternion.LookRotation(new Vector3(0,90,0)));
			targetInst.rigidbody.AddForce(Vector3.right*targetSpeed);
		}
	}
}
