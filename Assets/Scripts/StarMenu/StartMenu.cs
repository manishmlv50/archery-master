using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public Font titlefont_Large;
	public Font titlefont_Mid;
	public Font titlefont_Small;
	public Material titleMat_Large;
	public Material titleMat_Mid;
	public Material titleMat_Small;
	
	public Font menufont_Large;
	public Font menufont_Mid;
	public Font menufont_Small;
	public Material menuMat_Large;
	public Material menuMat_Mid;
	public Material menuMat_Small;
	
	private GUIText _title;
	private GUIText _newGame;
	private GUIText _continue;
	private GUIText _setting;
	private GUIText _tutorial;
	
	// Use this for initialization
	void Start () {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		titlefont_Large.material = titleMat_Large;
		titlefont_Mid.material = titleMat_Mid;
		titlefont_Small.material = titleMat_Small;
		
		menufont_Large.material = menuMat_Large;
		menufont_Mid.material = menuMat_Mid;
		menufont_Small.material = menuMat_Small;
		
		GameObject temp = new GameObject("Title");
		_title = (GUIText)temp.AddComponent(typeof(GUIText));
		
		temp = new GameObject("NewGame");
		_newGame = (GUIText)temp.AddComponent(typeof(GUIText));
		
		temp = new GameObject("Continue");
		_continue = (GUIText)temp.AddComponent(typeof(GUIText));
		
		temp = new GameObject("Setting");
		_setting = (GUIText)temp.AddComponent(typeof(GUIText));
		
		temp = new GameObject("Tutorial");
		_tutorial = (GUIText)temp.AddComponent(typeof(GUIText));
		
		if(Screen.width > 900) {
			_title.font = titlefont_Large;
			_title.pixelOffset = new Vector2(0.2f*screenWidth, 0.9f*screenHeight);
			
			_newGame.font = menufont_Large;
			_newGame.pixelOffset = new Vector2(0.7f*screenWidth, 0.6f*screenHeight);
			
			_continue.font = menufont_Large;
			_continue.pixelOffset = new Vector2(0.7f*screenWidth, 0.45f*screenHeight);
			
			_setting.font = menufont_Large;
			_setting.pixelOffset = new Vector2(0.7f*screenWidth, 0.3f*screenHeight);
			
			_tutorial.font = menufont_Large;
			_tutorial.pixelOffset = new Vector2(0.7f*screenWidth, 0.15f*screenHeight);
		}
		else if(Screen.width < 600) {
			_title.font = titlefont_Small;
			_title.pixelOffset = new Vector2(0.15f*screenWidth, 0.9f*screenHeight);
			
			_newGame.font = menufont_Small;
			_newGame.pixelOffset = new Vector2(0.6f*screenWidth, 0.6f*screenHeight);
			
			_continue.font = menufont_Small;
			_continue.pixelOffset = new Vector2(0.6f*screenWidth, 0.45f*screenHeight);
			
			_setting.font = menufont_Small;
			_setting.pixelOffset = new Vector2(0.6f*screenWidth, 0.3f*screenHeight);
			
			_tutorial.font = menufont_Small;
			_tutorial.pixelOffset = new Vector2(0.6f*screenWidth, 0.15f*screenHeight);
		}
		else {
			_title.font = titlefont_Mid;
			_title.pixelOffset = new Vector2(0.2f*screenWidth, 0.9f*screenHeight);
			
			_newGame.font = menufont_Mid;
			_newGame.pixelOffset = new Vector2(0.5f*screenWidth, 0.6f*screenHeight);
			
			_continue.font = menufont_Mid;
			_continue.pixelOffset = new Vector2(0.5f*screenWidth, 0.45f*screenHeight);
			
			_setting.font = menufont_Mid;
			_setting.pixelOffset = new Vector2(0.5f*screenWidth, 0.3f*screenHeight);
			
			_tutorial.font = menufont_Mid;
			_tutorial.pixelOffset = new Vector2(0.5f*screenWidth, 0.15f*screenHeight);
		}
		
		_title.text = "Archery Master";
		_newGame.text = "New Game";
		_continue.text = "Continue";
		_setting.text = "Setting";
		_tutorial.text = "Tutorial";
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch currentTouch in Input.touches){
			if(currentTouch.phase == TouchPhase.Ended && _newGame.HitTest(currentTouch.position)){
				Application.LoadLevel("Level");
			}
			
			if(currentTouch.phase == TouchPhase.Ended && _continue.HitTest(currentTouch.position)){
				Application.LoadLevel("Level");
			}
			
			if(currentTouch.phase == TouchPhase.Ended && _setting.HitTest(currentTouch.position)){
				Application.LoadLevel("Level");
			}
			
			if(currentTouch.phase == TouchPhase.Ended && _tutorial.HitTest(currentTouch.position)){
				Application.LoadLevel("Level");
			}
		}	
	}
}
