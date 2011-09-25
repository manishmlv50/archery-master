using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision c) {
			Destroy(c.gameObject);
    }
	
	void OnTriggerEnter(Collider c){
		Destroy(c.gameObject);
	}
	
	void Update () {
	
	}
}
