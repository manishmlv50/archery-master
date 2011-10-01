using UnityEngine;
using System.Collections;

public abstract class Target: MonoBehaviour
{	
	public static Targets TARGET_ID;
	public Transform explosion;
	public AudioClip destroySound;
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, 
		                            new Vector3(transform.position.x, transform.position.y, -30),
		                            1f);
	}
	
	public void createExplosion()
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		
	}
	
	abstract public void DoEffect(Arrow arrow);
}
