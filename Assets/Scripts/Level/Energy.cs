using UnityEngine;
using System.Collections;

/* Energy is accumulated over time when the player destroys targets 
 * This will be shown in an energy bar */

public class Energy : MonoBehaviour {
	
	public Transform super_wave;
	//public Transform super_condition;
	public Transform emitPoint;	
	
	public AudioClip max_energy_sound;
	
	//private Transform condition;
	
	public Texture texture;
	
	public int barWidth = 400;
	public int barHeight = 10;
	public float curr_power = 0;
	private float moveSpeed = 0;
	
	// Use this for initialization
	void Start () {
		curr_power = 0;
	}
	
	// Update is called once per frame
	void Update () {	
		if(Character.Inst.Super)
		{
			//condition.position = emitPoint.transform.position;
			curr_power -= Time.deltaTime * 40f; // During this time, the player will be superman.
			curr_power = Mathf.Clamp(curr_power, 0, barWidth);
			
			GameStatus.Inst.MoveSpeed = 30;
			
			if(curr_power < 1) {
				curr_power = 0;
				Character.Inst.Super = false;
				GameStatus.Inst.MoveSpeed = moveSpeed;
				//Destroy(condition.gameObject);
			}
		}
 
		/* Due to floating point imprecision it is not recommended to compare floats using the equal operator. 
		 * Ex: 1.0 == 10.0 / 10.0 might not return true. */
		if(Mathf.Approximately(curr_power , barWidth) && !Character.Inst.Super)
		{
			Character.Inst.Super = true;
			moveSpeed = GameStatus.Inst.MoveSpeed;
			Debug.Log(GameStatus.soundVol+" "+ max_energy_sound);
			AudioSource.PlayClipAtPoint(max_energy_sound, 
			                            new Vector3(emitPoint.position.x, 17.9f, -34), 
			                            GameStatus.soundVol);
			//condition = (Transform)Instantiate(super_condition,emitPoint.transform.position,Quaternion.identity);
			StartCoroutine("delay");
		}
	}
	
	void OnGUI()
	{
		GUI.BeginGroup(new Rect(Screen.width/2-barWidth/2,barHeight,curr_power,barHeight));
    	GUI.DrawTexture(new Rect( 0,0,barWidth,barHeight), texture );
    	GUI.EndGroup();
	}
	
	public void addEnergy(int e)
	{
		if(Character.Inst.Super)	// don't add energy during super mode
			return;	
		
		curr_power = curr_power + e;
		curr_power = Mathf.Clamp(curr_power, 0, barWidth);
	}
	
	IEnumerator delay() {
		Transform wave = (Transform) Instantiate(super_wave, emitPoint.transform.position,Quaternion.identity);
		yield return new WaitForSeconds(1f);
		Destroy(wave.gameObject);
	}
}

 
