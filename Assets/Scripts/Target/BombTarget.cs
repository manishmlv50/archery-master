using UnityEngine;
using System.Collections;

public class BombTarget : MonoBehaviour, TargetInterface {
	
	public AudioClip destroySound;
	public static int TARGET_ID = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, 
		                            new Vector3(transform.position.x, transform.position.y, -30),
		                            1f);
	}
	
	public int DoEffect(ArrowInterface arrow)
	{
		
		// Access Detonator script attached to "BombTarget"
		Detonator d = gameObject.GetComponent(typeof(Detonator)) as Detonator; 
		d.Explode(); // start destroy animation
		
		// Access Bomb Target script attached to "BombTarget"
		BombTarget bt = gameObject.GetComponent(typeof(BombTarget)) as BombTarget;
		bt.createSound();	// create destroy sound
		
		d.renderer.enabled = false; // hide bomb target object
		
		// Earn Score for destroying the Bomb Target
		GameStatus.Inst.earnScore(arrow.Counter++, TARGET_ID);
		
		// Find game objects with tag "Target"... this is for "Normal" targets
		GameObject[] gos = GameObject.FindGameObjectsWithTag("NormalTarget");
		foreach(GameObject go in gos)
		{
			// Check if the distance of the "BombTarget" and this "Target" is less than 25
			if(Vector3.Distance(gameObject.transform.position,
			                     go.transform.position) < 25)
			{
				// Destroy this object because it is within the distance threshold
				Destroy(go);
				
				// Score Points for this target
				TargetInterface ti = go.gameObject.GetComponent(typeof(TargetInterface)) as TargetInterface;
				ti.DoEffect(arrow);
			}
		}
		
		Destroy(this);
		return 1;	
	}
}
