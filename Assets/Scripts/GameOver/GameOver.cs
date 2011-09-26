using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	// Use this for initialization
	public Texture2D background; 
	public Font headerFont;
	public Font scoreFont;
	public Texture2D button;
	public Font buttonFont;
	
	
	private Rect header;
	private GUIStyle headerStyle;
	
	private Rect score;
	private	GUIStyle scoreStyle;
	
	private Rect buttonPosition;
	private GUIStyle buttonStyle;
	
	void Start(){
		header = new Rect(0,Screen.height*0.1f,Screen.width,Screen.height*0.2f);
		headerStyle = new GUIStyle();
		headerStyle.font = headerFont;
		headerStyle.normal.textColor = Color.red;
		headerStyle.alignment = TextAnchor.MiddleCenter;
		
		score = new Rect(0,Screen.height*0.35f,Screen.width,Screen.height*0.2f);
		scoreStyle = new GUIStyle();
		scoreStyle.font = scoreFont;
		scoreStyle.normal.textColor = Color.white;
		scoreStyle.alignment = TextAnchor.MiddleCenter;
		
		buttonPosition = new Rect(Screen.width*0.8f,Screen.height*0.75f,Screen.height*0.2f,Screen.height*0.2f);
		buttonStyle = new GUIStyle();
		buttonStyle.normal.background = button;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.font = buttonFont;
	}
	
	void OnGUI(){

		GUI.DrawTexture(new Rect (0,0,Screen.width,Screen.height),background, ScaleMode.StretchToFill);		
		
		GUI.Label(header,"Game Over",headerStyle);
		
		int s = 9999;
		if(GameStatus.Inst != null)
			s = GameStatus.Inst.Score;
		GUI.Label(score,"Score: "+s,scoreStyle);
		
		
		if(GUI.Button(buttonPosition,"Retry",buttonStyle))
		{
			Application.LoadLevel("Level");
		}
		
	}
}
