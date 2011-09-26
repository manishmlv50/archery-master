using UnityEngine;
using System.Collections;

/* Change Log
 * 
 * September 24, 2011 - BD
 * 		Added the following targets: BombTarget, FreezeTarget, TimeTarget
 * */

public class Arrow : MonoBehaviour, ArrowInterface {

	// Use this for initialization
	
	void Start () {
		Counter=0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c)
	{
		TargetInterface ti = c.gameObject.GetComponent(typeof(TargetInterface)) as TargetInterface;
		
		ti.DoEffect(this);
	}	
}
