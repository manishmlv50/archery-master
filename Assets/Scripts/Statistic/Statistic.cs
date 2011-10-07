using UnityEngine;
using System.Collections;

public class Statistic : MonoBehaviour {
	
	// Use this for initialization
	public AudioClip confirmSound;
	
	public Texture2D background; 
	public Font headerFont;
	public Font scoreFont;
	public GUIStyle buttonStyle;
	
	private Rect header;
	private GUIStyle headerStyle;
	
	private Rect score;
	private	GUIStyle scoreStyle;
	private Rect buttonPosition;
	
	public static int guiDepth = 1;
	
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
	}
	
	void OnGUI(){
		GUI.depth = guiDepth;
		GUI.DrawTexture(new Rect (0,0,Screen.width,Screen.height),background, ScaleMode.StretchToFill);		
		
		GUI.Label(header,"Congratulations",headerStyle);
		
		int s = 9999;
		if(GameStatus.Inst != null)
			s = GameStatus.Inst.Score;
		GUI.Label(score,"Score: "+s,scoreStyle);
		
		if(GUI.Button(buttonPosition,"Next",buttonStyle))
		{
			GameStatus.Level++;
			Loading.LOAD = true;
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			Application.LoadLevel("Level");
		}
		
	}
}
