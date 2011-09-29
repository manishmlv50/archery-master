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
	
	private float percentageLoaded = 0;
	private bool LOAD = false;
	private bool showSetting = false;
	private bool working = false;
	private int settingIdx = 0;
	
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
		working = LOAD | showSetting;
		
		if(LOAD) {
			GUI.skin.box.fontSize = 22 * Screen.height/640;
			percentageLoaded = Application.GetStreamProgressForLevel("Level") * 100;
			GUI.Box(new Rect(0.4f*Screen.width, 0.4f*Screen.height, 180*Screen.width/960, 40*Screen.height/640),
		    	    "Loading..." + percentageLoaded.ToString() + "%");
		}
		
		if(showSetting) {
			switch(settingIdx) {
			case 1:
				GUI.skin.box.fontSize = 24 * Screen.height/640;
				GUI.Box(new Rect(0.25f*Screen.width, 0.3f*Screen.height, 0.5f*Screen.width, 0.4f*Screen.height),
			    	    "Sound");
				DoSound();
				break;
				
			case 2:
				GUI.skin.box.fontSize = 24 * Screen.height/640;
				GUI.Box(new Rect(0.35f*Screen.width, 0.3f*Screen.height, 0.3f*Screen.width, 0.4f*Screen.height),
			    	    "Control");
				DoCtrl();
				break;
				
			case 3:
				GUI.skin.box.fontSize = 24 * Screen.height/640;
				GUI.Box(new Rect(0.4f*Screen.width, 0.3f*Screen.height, 0.2f*Screen.width, 0.3f*Screen.height),
			    	    "Language");
				DoLang();
				break;

			default:
				GUI.skin.box.fontSize = 24 * Screen.height/640;
				GUI.Box(new Rect(0.4f*Screen.width, 0.3f*Screen.height, 0.2f*Screen.width, 0.5f*Screen.height),
				        "Setting");
				DoSetting();
				break;
			}
		}
		
		if(Screen.width > 900) {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Large);
			
			
			if( GUI.Button(newGameRect,"New Game",menuStyle_Large) && !working) {		
				LOAD = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Large) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Large) ) {
				showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Large) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
		else if(Screen.width < 600) {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Small);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Small) && !showSetting ) {
				LOAD = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Small) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Small) ) {
				showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Small) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
		else {
			
			GUI.Label(titleRect,"Archery Master",titleStyle_Mid);
				
			if( GUI.Button(newGameRect,"New Game",menuStyle_Mid) ) {
				LOAD = true;
				AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
				Application.LoadLevel("Level");
			}
			
			if( GUI.Button(continueRect,"Continue",menuStyle_Mid) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(settingRect,"Setting",menuStyle_Mid) ) {
				showSetting = true;
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
			
			if( GUI.Button(tutorialRect,"Tutorial",menuStyle_Mid) ) {
				AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
			}
		}
	}
	
	void DoSetting() {
		float x = 0.025f*Screen.width + 0.4f*Screen.width;
		float y = 0.09f*Screen.height;
		float width = 0.15f*Screen.width;
		float height = 0.07f*Screen.height;
		
		if( GUI.Button(new Rect(x, 1f*y+0.3f*Screen.height, width, height), "Sound") ) {
			settingIdx = 1;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+0.3f*Screen.height, width, height), "Control") ) {
			settingIdx = 2;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+0.3f*Screen.height, width, height), "Language") ) {
			settingIdx = 3;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 4f*y+0.3f*Screen.height, width, height), "Back") ) {
			showSetting = false;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	void DoSound() {
		float x = 0.05f*Screen.width + 0.25f*Screen.width;
		float y = 0.1f*Screen.height;
		float width = 0.4f*Screen.width;
		float height = 0.08f*Screen.height;
		
		Rect rect = new Rect(x, 1f*y+0.3f*Screen.height, width, height);
		GameStatus.BGM = LabelSlider (rect, 100*GameStatus.BGM, 0, 100, "BGM");
		rect.y += y;
		GameStatus.soundVol = LabelSlider (rect, 100*GameStatus.soundVol, 0, 100, "Sound");
		rect.y += y;
		
		if( GUI.Button(rect, "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	void DoCtrl() {
		float x = 0.025f*Screen.width + 0.35f*Screen.width;
		float y = 0.09f*Screen.height;
		float width = 0.25f*Screen.width;
		float height = 0.07f*Screen.height;
		GUIStyle myStyle1 = new GUIStyle(GUI.skin.button);
		GUIStyle myStyle2 = new GUIStyle(GUI.skin.button);
				
		if(GameStatus.ctrl) {
			myStyle1.normal.textColor = Color.magenta;
			myStyle2.normal.textColor = Color.white;
		}
		else {
			myStyle1.normal.textColor = Color.white;
			myStyle2.normal.textColor = Color.magenta;
		}
		
		if( GUI.Button(new Rect(x, 1f*y+0.3f*Screen.height, width, height), "Virtual Joystick", myStyle1) ) {
			GameStatus.ctrl = true;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+0.3f*Screen.height, width, height), "Tilting", myStyle2) ) {
			GameStatus.ctrl = false;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+0.3f*Screen.height, width, height), "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	
	void DoLang() {
		float x = 0.025f*Screen.width + 0.4f*Screen.width;
		float y = 0.09f*Screen.height;
		float width = 0.15f*Screen.width;
		float height = 0.07f*Screen.height;
		
		if( GUI.Button(new Rect(x, 1f*y+0.3f*Screen.height, width, height), "English") ) {
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+0.3f*Screen.height, width, height), "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);			
		}
	}
	
	
	float LabelSlider (Rect screenRect, float sliderValue, float sliderMinValue,float sliderMaxValue, string labelText)
	{
		GUIStyle mystyle = new GUIStyle();
		mystyle.fontSize = 20 * Screen.height/640;
		mystyle.normal.textColor = Color.white;
		GUI.Label (screenRect, labelText, mystyle);
		screenRect.x += 0.2f*screenRect.width; 
		screenRect.y += 0.02f*screenRect.height;
		screenRect.width *= 0.8f;
		sliderValue = (int) GUI.HorizontalSlider(screenRect, sliderValue,sliderMinValue, sliderMaxValue);
		screenRect.x += 0.4f*screenRect.width;
		screenRect.y -= 0.02f*screenRect.height;
		screenRect.width /= 7f;
		GUI.Label (screenRect, sliderValue.ToString(), mystyle);
		return sliderValue*0.01f;
	}
}