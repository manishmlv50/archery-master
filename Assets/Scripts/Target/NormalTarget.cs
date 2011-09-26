using UnityEngine;
using System.Collections;

public class NormalTarget  : MonoBehaviour, TargetInterface
{
	public AudioClip destroySound;
	public Transform explosion;
	public static int TARGET_ID = 0;

	public NormalTarget ()
	{
	}
	
	public void createSound()
	{
		AudioSource.PlayClipAtPoint(destroySound, new Vector3(transform.position.x, transform.position.y, -30),2f);
	}
	
	public int DoEffect(ArrowInterface arrow)
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		createSound();
		GameStatus.Inst.earnScore(arrow.Counter++, TARGET_ID);
		Destroy(this);
		return 1;
	}
}


