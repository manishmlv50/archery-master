using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public AudioClip BGM;
	public Transform target;
	private float dampTime = 0.3f;
	private Vector3 velocity = new Vector3(1,1,1);
	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		//PlayAudioClip(BGM, new Vector3(transform.position.x,18.3f,-33.6f), GameStatus.BGM);
		if (target) {
			Vector3 point = gameObject.camera.WorldToViewportPoint (target.position);
			Vector3 delta = target.position - gameObject.camera.ViewportToWorldPoint (new Vector3 (0.5f, point.y, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}
	}
	
	AudioSource PlayAudioClip(AudioClip clip, Vector3 position, float volume) {
		GameObject go = new GameObject("audio");
		go.transform.position = position;
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.Play();
		source.loop = true;
		return source;
	}
}
