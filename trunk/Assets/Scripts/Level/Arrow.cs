using UnityEngine;
using System.Collections;

/* Change Log
 * 
 * September 24, 2011 - BD
 * 		Added the following targets: BombTarget, FreezeTarget, TimeTarget
 * */

public class Arrow : MonoBehaviour {

	// Use this for initialization

	private int counter = 0;
	public AudioClip destroySound;
	public Transform explosion;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.name.StartsWith("Target")){
			Instantiate(explosion, c.gameObject.transform.position, Quaternion.identity);
			Destroy(c.gameObject);
			GameStatus.Inst.Score += (int)(Database.HitTarget(0)*Mathf.Pow(GameStatus.Inst.ComboBonus,counter++)*GameStatus.Inst.ScoreBonus);
			AudioSource.PlayClipAtPoint(destroySound, new Vector3(transform.position.x, transform.position.y, -30),2f);
		}
		else if(c.gameObject.name.StartsWith("BombTarget"))
		{
			// Access Detonator script attached to "BombTarget"
			Detonator d = c.gameObject.GetComponent(typeof(Detonator)) as Detonator; 
			d.Explode(); // start destroy animation
			counter = counter + 1; // score points for destroying this
			
			// Access Bomb Target script attached to "BombTarget"
			BombTarget bt = c.gameObject.GetComponent(typeof(BombTarget)) as BombTarget;
			bt.createSound();	// create destroy sound
			
			d.renderer.enabled = false; // hide bomb target object
			
			// Find game objects with tag "Target"
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Target");
			foreach(GameObject go in gos)
			{
				// Check if the distance of the "BombTarget" and this "Target" is less than 25
				if(Vector3.Distance(c.gameObject.transform.position,
				                     go.transform.position) < 25)
				{
					// Destroy this object because it is within the distance threshold
					Destroy(go);
					
					// Score Points for this target
					counter = counter + 1;
				}
			}
			
			//GUIControl.Inst.EarnScore(counter); // earn score
			Destroy(this);
		}
		else if(c.gameObject.name.StartsWith("TimeTarget"))
		{
			// Access Detonator script attached to "TimeTarget"
			Detonator d = c.gameObject.GetComponent(typeof(Detonator)) as Detonator; 
			d.Explode(); // start destroy animation
			counter = counter + 1; // score points for destroying this
			
			// Access Time Target script attached to "TimeTarget"
			TimeTarget tt = c.gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
			tt.createSound();	// create destroy sound
			d.renderer.enabled = false; // hide time target object
			
			//GUIControl._curTime = GUIControl._curTime + TimeTarget.EXTRA_TIME;
			
			//GUIControl.Inst.EarnScore(counter); // earn score
		}
		else if(c.gameObject.name.StartsWith("FreezeTarget"))
		{
			// Access Detonator script attached to "BombTarget"
			Detonator d = c.gameObject.GetComponent(typeof(Detonator)) as Detonator; 
			d.Explode(); // start destroy animation
			
			// Access Freeze Target script attached to "FreezeTarget"
			FreezeTarget ft = c.gameObject.GetComponent(typeof(FreezeTarget)) as FreezeTarget;
			ft.createSound();	// create destroy sound
			d.renderer.enabled = false; // hide freeze target object
			
			FreezeTarget.lastTime = Time.time;
			FreezeTarget.isFrozen = true;
		}
	}
}
