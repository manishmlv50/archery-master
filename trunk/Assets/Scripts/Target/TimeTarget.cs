using UnityEngine;
using System.Collections;

public class TimeTarget : MonoBehaviour, TargetInterface {
	
	public static int EXTRA_TIME = 10;
	public AudioClip destroySound;
	public static int TARGET_ID = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int DoEffect(ArrowInterface arrow)
	{
		// Access Detonator script attached to "TimeTarget"
		Detonator d = gameObject.GetComponent(typeof(Detonator)) as Detonator; 
		d.Explode(); // start destroy animation
		
		// Earn Score
		GameStatus.Inst.earnScore(arrow.Counter++, TARGET_ID);
		
		// Access Time Target script attached to "TimeTarget"
		TimeTarget tt = gameObject.GetComponent(typeof(TimeTarget)) as TimeTarget;
		tt.createSound();	// create destroy sound
		d.renderer.enabled = false; // hide time target object
		
		// Add 10 seconds to level time
		GameStatus.Inst.Time += EXTRA_TIME;
		return 1;
	}
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, 
		                            new Vector3(transform.position.x, transform.position.y, -30),
		                            1f);
	}
}
