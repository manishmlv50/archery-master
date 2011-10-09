using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	// Use this for initialization
	public AudioClip confirmSound;
	
	public Texture2D background; 
	public Font headerFont_Large;
	public Font headerFont_Small;
	public Font scoreFont_Large;
	public Font scoreFont_Small;
	
	public GUIStyle buttonStyle;
	public Font buttonFont_Large;
	public Font buttonFont_Small;
	
	private Rect header;
	private GUIStyle headerStyle;
	
	private Rect score;
	private	GUIStyle scoreStyle;
	private Rect buttonPosition;
	
	public static int guiDepth = 1;
	
	void Start(){
		guiDepth = 1;
		
		header = new Rect(0,Screen.height*0.1f,Screen.width,Screen.height*0.2f);
		headerStyle = new GUIStyle();
		
		score = new Rect(0,Screen.height*0.35f,Screen.width,Screen.height*0.3f);
		scoreStyle = new GUIStyle();
		
		if(Screen.height > 500) {
			headerStyle.font = headerFont_Large;
			scoreStyle.font = scoreFont_Large;
			buttonStyle.font = buttonFont_Large;
		}
		else {
			headerStyle.font = headerFont_Small;
			scoreStyle.font = scoreFont_Small;
			buttonStyle.font = buttonFont_Small;
		}
		
		headerStyle.normal.textColor = Color.red;
		headerStyle.alignment = TextAnchor.MiddleCenter;
		
		scoreStyle.normal.textColor = Color.white;
		scoreStyle.alignment = TextAnchor.MiddleCenter;
		
		buttonPosition = new Rect(Screen.width*0.75f,Screen.height*0.75f,Screen.width*0.25f,Screen.height*0.2f);
	}
	
	void OnGUI(){
		GUI.depth = guiDepth;
		GUI.DrawTexture(new Rect (0,0,Screen.width,Screen.height),background, ScaleMode.StretchToFill);		
		
		GUI.Label(header,"Game Over",headerStyle);
		
		int s = 9999;
		if(GameStatus.Inst != null)
			s = GameStatus.Inst.Score;
		GUI.Label(score,"Score: "+s,scoreStyle);
		
		if(GUI.Button(buttonPosition,"Retry",buttonStyle))
		{
			Loading.LOAD = true;
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			Application.LoadLevel("Level");
		}
		
	}
}
