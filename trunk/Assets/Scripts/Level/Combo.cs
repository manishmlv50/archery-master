using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {

	// Use this for initialization

	public int c;
	
	private static Color [] colors= {Color.green,Color.yellow,Color.blue,Color.magenta};
	void Start () {
		TextMesh t = GetComponent<TextMesh>() as TextMesh;
		t.text = getText(c);
		t.renderer.material.color = colors[Random.Range(0,colors.Length)];
		
		int d = 1;
		if(Random.value<0.5)
			d = -1;
		gameObject.rigidbody.AddForce(new Vector3(Random.value*d,Random.Range(0.5f,1),0)*1000);
		Invoke("DestroySelf",2);
	}
	
	private string getText(int c)
	{
		/*switch (c){
			case 3: return "(Three)";
			case 4: return "(Four)";
			case 5: return "(Five)";
			case 6: return "(Six)";
			case 7: return "(Seven)";
			case 8: return "(Eight)";
			default: return "(Awnsome)";
		}*/
		return "Hits:"+c;
		
	}
	
	void DestroySelf()
	{
		Destroy(gameObject);
	}
}
