using UnityEngine;
using System.Collections;

public class BombTarget : MonoBehaviour, TargetInterface {
	
	public AudioClip destroySound;
	
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
	
	public int DoEffect(ArrowInterface arrow, ArrayList targets, CharacterInterface c)
	{
		return 1;	
	}
}
