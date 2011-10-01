using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {

	// Use this for initialization
	
	public Material combo1;
	public Material combo2;
	public Material combo3;
	private Material[] ms;
	public int c;
	
	void Start () {
		TextMesh t = GetComponent<TextMesh>() as TextMesh;
		ms = new Material[3];
		ms[0] = combo1;
		ms[1] = combo2;
		ms[2] = combo3;
		t.text = "Hits "+c;
		t.renderer.material = ms[c%3];
		
		int d = 1;
		if(Random.value<0.5)
			d = -1;
		gameObject.rigidbody.AddForce(new Vector3(Random.value*d,Random.value,0)*1000);
		Invoke("DestroySelf",2);
	}
	
	void DestroySelf()
	{
		Destroy(gameObject);
	}
}
