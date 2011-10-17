using UnityEngine;
using System.Collections;

public class ReflectorWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider c)
	{
		if(c.gameObject.name == "Fireball(Clone)"){
			c.rigidbody.AddForce(-c.transform.forward * 10000);
			//c.rigidbody.rotation = Quaternion.LookRotation(-Vector3.forward);	
		}
	}
}
