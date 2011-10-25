using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public GameObject hpGameObject;
	// Use this for initialization
	void Start () {
		PackedSprite ps = hpGameObject.GetComponent<PackedSprite>();
		ps.PlayAnim(GameStatus.Inst.HP);
	}
	
	void OnCollisionEnter(Collision c) {
		Target t = c.gameObject.GetComponent<Target>();
		if(t != null){
			PackedSprite ps = hpGameObject.GetComponent<PackedSprite>();
			GameStatus.Inst.HP -= t.missPunish;
			ps.PlayAnim(GameStatus.Inst.HP<0? 0:GameStatus.Inst.HP);
		}
		Destroy(c.gameObject);
		
    }
	
	void OnTriggerEnter(Collider c){
		Destroy(c.gameObject);
	}
	
	void Update () {
	
	}
}
