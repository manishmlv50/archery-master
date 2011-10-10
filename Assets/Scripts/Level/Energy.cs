using UnityEngine;
using System.Collections;

/* Energy is accumulated over time when the player destroys targets 
 * This will be shown in an energy bar */

public class Energy : MonoBehaviour {
	
	public Transform super_wave;
	public Transform super_condition;
	public Transform emitPoint;	
	
	public static float energy_bar_width = 200.0f;
	public static float curr_power = 0.0f;
	public GUITexture energy_bar;
	public AudioClip max_energy_sound;
	private static bool super_mode = false;
	
	private int tempNum = 0;
	private Transform condition;
	
	// Use this for initialization
	void Start () {
		//float screenWidth = Screen.width;
		//float screenHeight = Screen.height;
		
		curr_power = 0.0f;
		tempNum = 0;
		super_mode = false;
		
		energy_bar = gameObject.GetComponent<GUITexture>();
		Rect temp = new Rect((Screen.width - energy_bar.pixelInset.width)/2,
		                     (Screen.height - energy_bar.pixelInset.height)/2,
		                     energy_bar.pixelInset.width,
		                     energy_bar.pixelInset.height); //(100, -30, 200, 20);
		temp.width = 0.0f;
		energy_bar.pixelInset = temp;
	}
	
	// Update is called once per frame
	void Update () {	
		if(super_mode)
		{
			condition.position = emitPoint.transform.position;
			curr_power -= Time.deltaTime * 10.0f; // During this time, the player will be superman.
			curr_power = Mathf.Clamp(curr_power, 0, energy_bar_width);
			
			GameStatus.Inst.MoveSpeed = 30;
			GameStatus.Inst.ArrowCount = 999;
			
			if(Mathf.Approximately(curr_power, 0)) {
				super_mode = false;	
				GameStatus.Inst.MoveSpeed = 20;
				GameStatus.Inst.ArrowCount = tempNum;
				Destroy(condition.gameObject);
			}
		}
 
		/* Due to floating point imprecision it is not recommended to compare floats using the equal operator. 
		 * Ex: 1.0 == 10.0 / 10.0 might not return true. */
		if(Mathf.Approximately(curr_power, energy_bar_width) && super_mode == false)
		{
			super_mode = true;
			tempNum = GameStatus.Inst.ArrowCount;
			
			AudioSource.PlayClipAtPoint(max_energy_sound, 
			                            new Vector3(transform.position.x, 17.9f, -34), 
			                            GameStatus.soundVol);
			
			condition = (Transform)Instantiate(super_condition,emitPoint.transform.position,Quaternion.identity);
			
			StartCoroutine("delay");
		}
		
	    /* Set the width of the GUI Texture equal to the energy value */
	    Rect temp2 = energy_bar.pixelInset;
		temp2.width = curr_power;
		energy_bar.pixelInset = temp2;
	}
	
	public static void addEnergy(float e)
	{
		if(super_mode)	// don't add energy during super mode
			return;	
		
		curr_power = curr_power + e;	
		curr_power = Mathf.Clamp(curr_power, 0, energy_bar_width);
	}
	
	IEnumerator delay() {
		Transform wave = (Transform) Instantiate(super_wave, emitPoint.transform.position,Quaternion.identity);
		yield return new WaitForSeconds(1f);
		Destroy(wave.gameObject);
	}
}

 
