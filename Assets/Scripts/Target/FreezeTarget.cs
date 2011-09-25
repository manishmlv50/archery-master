using UnityEngine;
using System.Collections;

public class FreezeTarget : MonoBehaviour, TargetInterface {
	
	public AudioClip destroySound;
	public static bool isFrozen = false;
	public static float FREEZETIME = 5.0f; // 10 seconds
	public static float lastTime = 0.0f;
	
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
	
	public int DoEffect(ArrowInterface arrow, ArrayList targets, CharacterInterface c)
	{
		return 1;	
	}
}
