using UnityEngine;
using System.Collections;

public abstract class Target: MonoBehaviour
{	
	public Targets TARGET_ID;
	public Transform explosion;
	public AudioClip destroySound;
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, Camera.mainCamera.transform.position, GameStatus.soundVol);
	}
	
	public void createExplosion()
	{
		if(explosion != null)
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		
	}
	
	abstract public void DoEffect(Arrow arrow);
}
