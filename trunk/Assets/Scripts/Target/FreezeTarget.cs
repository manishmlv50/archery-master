using UnityEngine;
using System.Collections;

public class FreezeTarget : MonoBehaviour, TargetInterface {
	
	public AudioClip destroySound;
	public static bool isFrozen = false;
	public static float FREEZETIME = 5.0f; // 10 seconds
	public static float lastTime = 0.0f;
	public static int TARGET_ID = 2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
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
		
		// Access Freeze Target script attached to "FreezeTarget"
		FreezeTarget ft = gameObject.GetComponent(typeof(FreezeTarget)) as FreezeTarget;
		ft.createSound();	// create destroy sound
		d.renderer.enabled = false; // hide freeze target object
		
		FreezeTarget.lastTime = Time.time;
		FreezeTarget.isFrozen = true;
		return 1;	
	}
}
