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
			Debug.print("arrow hit");	
			
			c.rigidbody.velocity = -c.rigidbody.velocity;
			//c.rigidbody.AddForce(-c.transform.forward * 5000);
			//c.rigidbody.rotation = Quaternion.LookRotation(-Vector3.forward);
		}
	}
}
