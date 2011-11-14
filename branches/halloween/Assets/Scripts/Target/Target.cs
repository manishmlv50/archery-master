using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Target: MonoBehaviour
{	
	private static Vector3 POOL_POSITION = new  Vector3(0,100,0);
	protected Targets TARGET_ID;
	protected bool effected = false;

	public Transform explosion;
	public AudioClip destroySound;
	public Vector3 leftFace = Vector3.back;
	public Vector3 rightFace = Vector3.back;
	public int missPunish = 0;
	
	private static Dictionary<Target,bool> targetPool = new Dictionary<Target, bool>();
	
	public void recycle()
	{
		targetPool[this] = true;
		//gameObject.active = false;
		transform.position = POOL_POSITION;
		POOL_POSITION = POOL_POSITION + Vector3.right*15;
		if(POOL_POSITION.x > 100)
		{
			POOL_POSITION.x = 0;
			POOL_POSITION.z += 15;
		}
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
	
	public static void clearPool()
	{
		targetPool.Clear();
	}
	
	public static Target allocateTarget(Targets id, Transform tf, Vector3 pos, bool left, int speed)
	{
		Debug.Log("pool size:"+targetPool.Count);
		Target result = null;
		foreach(var keyvalue in targetPool)
		{
			Target t = keyvalue.Key;
			if (t.TARGET_ID == id && keyvalue.Value)
			{
				result = t;
				targetPool[t] = false;
				t.gameObject.active = true;
				break;
			}
		}
		
		if(result == null)
		{
			Transform targetInst = (Transform)Instantiate(tf);
			result = targetInst.GetComponent<Target>();
			targetPool.Add(result,false);
		}
		result.transform.position = pos;
		if(left){
			result.transform.rotation = Quaternion.LookRotation(result.leftFace);
			result.rigidbody.AddForce(Vector3.right*speed);
		}
		else
		{
			result.transform.rotation = Quaternion.LookRotation(result.rightFace);
			result.rigidbody.AddForce(Vector3.left*speed);
		}
		result.Resume();
		return result;
	}
	
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
	virtual public void Resume()
	{
		effected = false;
	}
}
