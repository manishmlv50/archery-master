using UnityEngine;
using System.Collections;

public abstract class Target: MonoBehaviour
{	
	public Targets TARGET_ID;
	public Transform explosion;
	public AudioClip destroySound;
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, 
		                            new Vector3(transform.position.x, 18.83f, -33.66f),
		                            1f);
	}
	
	public void createExplosion()
	{
		if(explosion != null)
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		
	}
	
	abstract public void DoEffect(Arrow arrow);
}
