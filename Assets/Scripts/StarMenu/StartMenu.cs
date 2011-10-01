using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public GUIStyle titleStyle_Small;
	public GUIStyle titleStyle_Mid;
	public GUIStyle titleStyle_Large;
	
	public GUIStyle menuStyle_Small;
	public GUIStyle menuStyle_Mid;
	public GUIStyle menuStyle_Large;
	
	public AudioClip confirmSound;
	public AudioClip menuOpenSound;
	public AudioClip menuCloseSound;
	
	private Rect titleRect;
	private Rect newGameRect;
	private Rect continueRect;
	private Rect settingRect;
	private Rect tutorialRect;
	
	private bool working = false;
	public static int guiDepth = 2;
	
	// Use this for initialization
	void Start () {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		// set each button position
		titleRect = new Rect(0.2f*screenWidth,0.1f*screenHeight,0.8f*screenWidth,0.25f*screenHeight);
		newGameRect = new Rect(0.65f*screenWidth,0.4f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		continueRect = new Rect(0.65f*screenWidth,0.55f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		settingRect = new Rect(0.65f*screenWidth,0.7f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		tutorialRect = new Rect(0.65f*screenWidth,0.85f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
	}
		
	void OnGUI(){
		GUI.depth = guiDepth;
		// if working, that means other buttons except the current ones couldn't work
		// ex: if we open setting window, then the button on the beginning start menu
		// like New Game, Continue... can't work
		working = Loading.LOAD | OpenMenu.showNewGame | OpenMenu.showContinue | 
			OpenMenu.showSetting | OpenMenu.tutorMode;
		
		// Adjust the arrangement according to diff resolutions
		if(Screen.width > 900) {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Large);
			
			
			if( GUI.Button(newGameRect,"New Game",menuStyle_Large) && !working) {
				OpenMenu.showNewGame = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Large) && !working) {
				OpenMenu.showContinue = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Large) && !working ) {
				OpenMenu.showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Large) && !working ) {
				//OpenMenu.tutorMode = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
		else if(Screen.width < 600) {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Small);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Small) && !working) {
				OpenMenu.showNewGame = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Small) && !working ) {
				OpenMenu.showContinue = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Small) && !working ) {
				OpenMenu.showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Small) && !working ) {
				//OpenMenu.tutorMode = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
		else {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Mid);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Mid) && !working ) {
				OpenMenu.showNewGame = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Mid) && !working ) {
				OpenMenu.showContinue = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Mid) && !working ) {
				OpenMenu.showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Mid) && !working ) {
				//OpenMenu.tutorMode = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
	}
}