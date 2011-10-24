using UnityEngine;
using System.Collections;

public abstract class Target: MonoBehaviour
{	
	protected Targets TARGET_ID;
	protected bool effected = false;
	
	public Transform explosion;
	public AudioClip destroySound;
	public Vector3 leftFace = Vector3.back;
	public Vector3 rightFace = Vector3.back;
	public int missPunish = 0;
	
	
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
