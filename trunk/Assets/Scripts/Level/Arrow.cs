using UnityEngine;
using System.Collections;

/* Change Log
 * 
 * September 24, 2011 - BD
 *              Added the following targets: BombTarget, FreezeTarget, TimeTarget
 * */

public class Arrow : MonoBehaviour
{
	// Use this for initialization
	public Transform comboPrefab;
	private int _combo;
	public static int DMG_AMOUNT = 25;
	
	public int Combo {
		get {
			return _combo;
		}
		set {
			_combo = value;
			if(_combo >=3)
			{
				Transform inst = (Transform)Instantiate(comboPrefab,transform.position,Quaternion.identity);
				Combo com = inst.GetComponent<Combo>();
				if(com!=null)
					com.c = Combo;
			}
		}
	}
	void Start ()
	{
		_combo = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider c)
	{
		Target ti = c.gameObject.GetComponent<Target> ();
		if (ti != null) {
			ti.DoEffect (this);
		}
	}
}
