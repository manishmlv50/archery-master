using UnityEngine;
using System.Collections;

public class TimeTarget : MonoBehaviour, TargetInterface {
	
	public static int EXTRA_TIME = 10;
	public AudioClip destroySound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int DoEffect(ArrowInterface arrow, ArrayList targets, CharacterInterface c)
	{
		return 1;
	}
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, 
		                            new Vector3(transform.position.x, transform.position.y, -30),
		                            1f);
	}
}
