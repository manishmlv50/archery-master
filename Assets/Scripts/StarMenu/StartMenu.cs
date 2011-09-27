using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public Font titlefont_Large;
	public Font titlefont_Mid;
	public Font titlefont_Small;
	
	public Font menufont_Large;
	public Font menufont_Mid;
	public Font menufont_Small;
	
	public GUIStyle titleStyle_Small;
	public GUIStyle titleStyle_Mid;
	public GUIStyle titleStyle_Large;
	
	public GUIStyle menuStyle_Small;
	public GUIStyle menuStyle_Mid;
	public GUIStyle menuStyle_Large;
	
	private Rect titleRect;
	private Rect newGameRect;
	private Rect continueRect;
	private Rect settingRect;
	private Rect tutorialRect;
	
	// Use this for initialization
	void Start () {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		titleRect = new Rect(0.2f*screenWidth,0.1f*screenHeight,0.8f*screenWidth,0.25f*screenHeight);
		newGameRect = new Rect(0.65f*screenWidth,0.4f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		continueRect = new Rect(0.65f*screenWidth,0.55f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		settingRect = new Rect(0.65f*screenWidth,0.7f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
		tutorialRect = new Rect(0.65f*screenWidth,0.85f*screenHeight,0.28f*screenWidth,0.065f*screenHeight);
	}
		
	void OnGUI(){
		if(Screen.width > 900) {
			GUI.Label(titleRect,"Archery Master",titleStyle_Large);					
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Large) ) {
				
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Large) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Large) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Large) ) {
				Application.LoadLevel("Level");
			}
		}
		else if(Screen.width < 600) {
			GUI.Label(titleRect,"Archery Master",titleStyle_Small);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Small) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Small) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Small) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Small) ) {
				Application.LoadLevel("Level");
			}
		}
		else {
			GUI.Label(titleRect,"Archery Master",titleStyle_Mid);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Mid) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Mid) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Mid) ) {
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Mid) ) {
				Application.LoadLevel("Level");
			}
		}
	}
}