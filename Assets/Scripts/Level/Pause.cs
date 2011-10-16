using System;
using UnityEngine;

public class Pause: MonoBehaviour
{
	public GUISkin skin;
	private bool show = false;
	public AudioClip confirmSound;
	
	void OnGUI () {
		GUI.skin = skin;
		if (GUI.Button (new Rect (Screen.width-5-Screen.width/10,5,Screen.width/10,Screen.height/20), "Pause")) {
			show = !show;
			Time.timeScale = 1-Time.timeScale;
		}
		
		if(show){
			GUI.BeginGroup(new Rect((Screen.width-512)/2, (Screen.height-512)/2,512,512));
			GUI.Box(new Rect(0, 0,512,512),"PAUSE");
			if(GUI.Button(new Rect(60, 210,400,50),"Resume")){
				show = !show;
				Time.timeScale = 1-Time.timeScale;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if(GUI.Button(new Rect(60, 300,400,50),"Retry")){
				Time.timeScale = 1-Time.timeScale;
				Loading.LOAD = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
				Application.LoadLevel("Level");
			}
			
			if(GUI.Button(new Rect(60, 390,400,50),"Main Menu")){
				Time.timeScale = 1-Time.timeScale;
				Loading.LOAD = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
				Application.LoadLevel("StartMenu");
			}
			GUI.EndGroup();
			
		}
			
	}

}


