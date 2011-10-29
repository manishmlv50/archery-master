using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour {
	
	public AudioClip confirmSound;
	public AudioClip menuOpenSound;
	public AudioClip menuCloseSound;
	
	public Font buttonFont_Large;
	public Font buttonFont_Small;
	public Font boxFont_Large;
	public Font boxFont_Small;
	
	public static bool showNewGame = false;
	public static bool showContinue = false;
	public static bool showSetting = false;
	public static bool tutorMode = false;
	
	private int settingIdx = 0;
	private int newGameIdx = 0;
	private int continuteIdx = 0;
	
	public Texture2D boxBackgound;
	public static int guiDepth = 1;

	// Use this for initialization
	void Start () {
		showNewGame = false;
		showContinue = false;
		showSetting = false;
		tutorMode = false;
		settingIdx = 0;
		newGameIdx = 0;
		continuteIdx = 0;
		guiDepth = 1;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin.box.normal.background = boxBackgound;
		if(Loading.LOAD) {
			if(Screen.width > 900)
				GUI.skin.box.font = boxFont_Large;
			else
				GUI.skin.box.font = boxFont_Small;
		}
		else {
			if(Screen.width > 900) {
				GUI.skin.box.font = boxFont_Large;
				GUI.skin.button.font = buttonFont_Large;
			}
			else {
				GUI.skin.box.font = boxFont_Small;
				GUI.skin.button.font = buttonFont_Small;
			}
		}
		
		GUI.depth = guiDepth;
		
		// Open the menu when press "New Game"
		if(showNewGame) {
			switch(newGameIdx) {
			case 1:
				DoLevel( new Rect(0.1f*Screen.width, 0.25f*Screen.height, 0.8f*Screen.width, 0.5f*Screen.height),
				        "Level Mode" );
				break;
				
			case 2:
				DoChallenge(new Rect(0.1f*Screen.width, 0.25f*Screen.height, 0.8f*Screen.width, 0.5f*Screen.height),
				            "Challenge");
				break;

			default:
				DoNewGame(new Rect(0.3f*Screen.width, 0.2f*Screen.height, 0.4f*Screen.width, 0.6f*Screen.height),
				          "New Game");
				break;
			}
		}
		
		// Open the menu when press "Continue"
		else if(showContinue) {
			switch(continuteIdx) {
			case 1:
				DoNewGame(new Rect(0.3f*Screen.width, 0.2f*Screen.height, 0.4f*Screen.width, 0.6f*Screen.height),
				          "Profile 1");
				break;
				
			case 2:
				DoNewGame(new Rect(0.3f*Screen.width, 0.2f*Screen.height, 0.4f*Screen.width, 0.6f*Screen.height),
				          "Profile 2");
				break;
				
			case 3:
				DoNewGame(new Rect(0.3f*Screen.width, 0.2f*Screen.height, 0.4f*Screen.width, 0.6f*Screen.height),
				          "Profile 3");
				break;

			default:
				DoContinue(new Rect(0.3f*Screen.width, 0.1f*Screen.height, 0.4f*Screen.width, 0.8f*Screen.height),
				          "Continue");
				break;
			}
		}
		
		// Open the menu when press "Setting"
		if(showSetting) {
			switch(settingIdx) {
			case 1:
				DoSound(new Rect(0.1f*Screen.width, 0.2f*Screen.height, 0.8f*Screen.width, 0.6f*Screen.height),
			    	    "Sound");
				break;
				
			case 2:
				DoCtrl(new Rect(0.3f*Screen.width, 0.2f*Screen.height, 0.4f*Screen.width, 0.6f*Screen.height),
				       "Control");
				break;
				
			case 3:
				DoLang(new Rect(0.3f*Screen.width, 0.25f*Screen.height, 0.4f*Screen.width, 0.5f*Screen.height),
				       "Language");
				break;

			default:
				DoSetting(new Rect(0.3f*Screen.width, 0.1f*Screen.height, 0.4f*Screen.width, 0.8f*Screen.height),
				          "Setting");
				break;
			}
		}
		
	}
	
	// Set the New Game menu
	void DoNewGame(Rect rect, string title) {
		int buttonRow = 4;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);		
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, width, height), "Level Mode") ) {
			newGameIdx = 1;
			showNewGame = true;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, width, height), "Challenge Mode") ) {
			newGameIdx = 2;
			showNewGame = true;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+rect.y, width, height), "Back") ) {
			
			if(showNewGame)
				showNewGame = false;
			else if(showContinue)
				continuteIdx = 0;
			
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	// Set the Continue menu
	void DoContinue(Rect rect, string title) {
		int buttonRow = 5;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, width, height), "Profile 1") ) {
			continuteIdx = 1;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, width, height), "Profile 2") ) {
			continuteIdx = 2;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+rect.y, width, height), "Profile 3") ) {
			continuteIdx = 3;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 4f*y+rect.y, width, height), "Back") ) {
			showContinue = false;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	
	// Set the Setting menu
	void DoSetting(Rect rect, string title) {
		int buttonRow = 5;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, width, height), "Sound") ) {
			settingIdx = 1;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, width, height), "Control") ) {
			settingIdx = 2;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+rect.y, width, height), "Language") ) {
			settingIdx = 3;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 4f*y+rect.y, width, height), "Back") ) {
			showSetting = false;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	// Set the Sound menu
	void DoSound(Rect rect, string title) {
		int buttonRow = 4;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		Rect area = new Rect(x, 1f*y+rect.y, width, height);
		GameStatus.BGM = LabelSlider (area, 100*GameStatus.BGM, 0, 100, "BGM");
		area.y += y;
		GameStatus.soundVol = LabelSlider (area, 100*GameStatus.soundVol, 0, 100, "Sound");
		area.y += y;
		
		if( GUI.Button(area, "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	// Set the Control menu
	void DoCtrl(Rect rect, string title) {
		int buttonRow = 4;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		GUIStyle myStyle1 = new GUIStyle(GUI.skin.button);
		GUIStyle myStyle2 = new GUIStyle(GUI.skin.button);
				
		if(GameStatus.tilting) {
			myStyle1.normal.textColor = Color.magenta;
			myStyle1.hover.textColor = Color.magenta;
			myStyle1.active.textColor = Color.magenta;
			myStyle2.normal.textColor = Color.white;
			myStyle2.hover.textColor = Color.white;
			myStyle2.active.textColor = Color.white;
		}
		else {
			myStyle1.normal.textColor = Color.white;
			myStyle1.hover.textColor = Color.white;
			myStyle1.active.textColor = Color.white;
			myStyle2.normal.textColor = Color.magenta;
			myStyle2.hover.textColor = Color.magenta;
			myStyle2.active.textColor = Color.magenta;
		}
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, width, height), "Tilting On", myStyle1) ) {
			GameStatus.tilting = true;
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, width, height), "Tilting off", myStyle2) ) {
			GameStatus.tilting = false;
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 3f*y+rect.y, width, height), "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
	}
	
	// Set the Language menu
	void DoLang(Rect rect, string title) {
		int buttonRow = 3;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, width, height), "English") ) {
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, width, height), "Back") ) {
			settingIdx = 0;
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);			
		}
	}
	
	// Set the level select menu
	void DoLevel(Rect rect, string title) {
		int buttonRow = 3;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		if( GUI.Button(new Rect(x+0.2f*width, 1f*y+rect.y, 0.6f*width, height), "Level " + (GameStatus.Level+1) ) ) {
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, 0.15f*width, height), "<") ) {
			if(GameStatus.Level > 0) GameStatus.Level--;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x+0.85f*width, 1f*y+rect.y, 0.15f*width, height), ">") ) {
			if(GameStatus.Level < 8) GameStatus.Level++;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, 0.4f*width, height), "Back") ) {
			if(showContinue) {
				showNewGame = false;
				newGameIdx = 0;
			}
			else
				newGameIdx = 0;
			
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x+0.6f*width, 2f*y+rect.y, 0.4f*width, height), "OK") ) {
			Loading.LOAD = true;
			Start();
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			
			if(GameStatus.Level > 4) 
				Application.LoadLevel("Level_ruin");
			else
				Application.LoadLevel("Level");
		}
	}
	
	// Set the level select menu
	void DoChallenge(Rect rect, string title) {
		int buttonRow = 3;
		float x = rect.x + 0.1f*rect.width;
		float y = 0.9f*rect.height / buttonRow;
		float width = 0.8f * rect.width;
		float height = 0.8f*y;
		
		GUI.Box(rect, title);
		
		if( GUI.Button(new Rect(x+0.2f*width, 1f*y+rect.y, 0.6f*width, height), "Level " + (GameStatus.Level+1) ) ) {
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 1f*y+rect.y, 0.15f*width, height), "<") ) {
			if(GameStatus.Level > 0) GameStatus.Level--;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x+0.85f*width, 1f*y+rect.y, 0.15f*width, height), ">") ) {
			GameStatus.Level++;
			AudioSource.PlayClipAtPoint(menuOpenSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x, 2f*y+rect.y, 0.4f*width, height), "Back") ) {
			if(showContinue) {
				showNewGame = false;
				newGameIdx = 0;
			}
			else
				newGameIdx = 0;
			
			AudioSource.PlayClipAtPoint(menuCloseSound, new Vector3(0,1,-10), GameStatus.soundVol);
		}
		
		if( GUI.Button(new Rect(x+0.6f*width, 2f*y+rect.y, 0.4f*width, height), "OK") ) {
			Loading.LOAD = true;
			Start();
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			Application.LoadLevel("Level");
		}
	}
	
	// Function of slide bar
	float LabelSlider (Rect screenRect, float sliderValue, float sliderMinValue,float sliderMaxValue, string labelText)
	{
		GUIStyle mystyle = new GUIStyle();
		mystyle.fontSize = 32 * Screen.height/640;
		mystyle.normal.textColor = Color.white;
		GUI.Label (screenRect, labelText, mystyle);
		screenRect.x += 0.2f*screenRect.width; 
		screenRect.y += 0.09f*screenRect.height;
		screenRect.width *= 0.8f;
		sliderValue = (int) GUI.HorizontalSlider(screenRect, sliderValue,sliderMinValue, sliderMaxValue);
		screenRect.x += 0.4f*screenRect.width;
		screenRect.y -= 0.09f*screenRect.height;
		screenRect.width /= 7f;
		GUI.Label (screenRect, sliderValue.ToString(), mystyle);
		return sliderValue*0.01f;
	}
}
