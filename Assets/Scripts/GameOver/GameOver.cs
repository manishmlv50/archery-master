using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
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
	private bool LOAD = false;
	private float percentageLoaded = 0;
	
	void Start(){
		header = new Rect(0,Screen.height*0.1f,Screen.width,Screen.height*0.2f);
		headerStyle = new GUIStyle();
		headerStyle.font = headerFont;
		headerStyle.normal.textColor = Color.red;
		headerStyle.alignment = TextAnchor.MiddleCenter;
		
		score = new Rect(0,Screen.height*0.35f,Screen.width,Screen.height*0.3f);
		scoreStyle = new GUIStyle();
		scoreStyle.font = scoreFont;
		scoreStyle.normal.textColor = Color.white;
		scoreStyle.alignment = TextAnchor.MiddleCenter;
		
		buttonPosition = new Rect(Screen.width*0.8f,Screen.height*0.75f,Screen.width*0.2f,Screen.height*0.2f);
	}
	
	void OnGUI(){

		GUI.DrawTexture(new Rect (0,0,Screen.width,Screen.height),background, ScaleMode.StretchToFill);		
		
		GUI.Label(header,"Game Over",headerStyle);
		
		int s = 9999;
		if(GameStatus.Inst != null)
			s = GameStatus.Inst.Score;
		GUI.Label(score,"Score: "+s,scoreStyle);
		
		
		if(LOAD) {
			GUI.skin.box.fontSize = 22 * Screen.height/640;
			percentageLoaded = Application.GetStreamProgressForLevel("Level") * 100;
			GUI.Box(new Rect(0.4f*Screen.width, 0.4f*Screen.height, 180*Screen.width/960, 40*Screen.height/640),
		    	    "Loading..." + percentageLoaded.ToString() + "%");
		}
		
		if(GUI.Button(buttonPosition,"Retry",buttonStyle))
		{
			LOAD = true;
			AudioSource.PlayClipAtPoint(confirmSound, new Vector3(0,1,-10), GameStatus.soundVol);
			Application.LoadLevel("Level");
		}
		
	}
}
