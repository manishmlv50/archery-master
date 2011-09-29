using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	
	public Font scorefont_Large;
	public Font scorefont_Mid;
	public Font scorefont_Small;
	
	public Font timefont_Large;
	public Font timefont_Mid;
	public Font timefont_Small;
	
	public GUITexture moveButton;
	public GUITexture shootButton;
	public GUITexture moveStick;
	
	private GUIStyle scoreStyle_Small;
	private GUIStyle scoreStyle_Mid;
	private GUIStyle scoreStyle_Large;
	
	private GUIStyle timeStyle_Small;
	private GUIStyle timeStyle_Mid;
	private GUIStyle timeStyle_Large;
	
	private Rect scoreRect;
	private Rect timeRect;
	private Rect levelRect;
	private Rect targetRect;
	private Rect arrowRect;
	private Rect powerRect;
	
	void Start () {
		
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		if(GameStatus.ctrl) {
			moveButton.pixelInset = new Rect(0.11f*screenWidth,
		    	                             0.04f*screenWidth,
		        	                         0.18f*screenWidth,
		            	                     0.18f*screenWidth
		                	                 );
		
			moveStick.pixelInset = new Rect (0.15f*screenWidth,
		    	                             0.04f*screenWidth+ (0.18f*screenWidth-0.03f*screenHeight)/2,
		        	                         0.1f*screenWidth,
		            	                     0.03f*screenHeight
		                	                 );
		
			shootButton.pixelInset = new Rect(screenWidth - 0.18f*screenWidth - 0.04f*screenWidth,
		    	                             0.04f*screenWidth,
		        	                         0.18f*screenWidth,
		            	                     0.18f*screenWidth
		                	                 );
		}
		else {
			moveStick.enabled = false;
			moveButton.enabled = false;
			shootButton.enabled = false;
		}
				
		scoreStyle_Small = new GUIStyle();
		scoreStyle_Small.normal.textColor = Color.cyan;
		scoreStyle_Small.font = scorefont_Small;
		
		scoreStyle_Mid = new GUIStyle();
		scoreStyle_Mid.normal.textColor = Color.cyan;
		scoreStyle_Mid.font = scorefont_Mid;
		
		scoreStyle_Large = new GUIStyle();
		scoreStyle_Large.normal.textColor = Color.cyan;
		scoreStyle_Large.font = scorefont_Large;
		
		timeStyle_Small = new GUIStyle();
		timeStyle_Small.normal.textColor = Color.red;
		timeStyle_Small.font = timefont_Small;
		
		timeStyle_Mid = new GUIStyle();
		timeStyle_Mid.normal.textColor = Color.red;
		timeStyle_Mid.font = timefont_Mid;
		
		timeStyle_Large = new GUIStyle();
		timeStyle_Large.normal.textColor = Color.red;
		timeStyle_Large.font = timefont_Large;
		
		scoreRect = new Rect(0.7f*screenWidth,0.02f*screenWidth,0.3f*screenWidth,0.05f*screenWidth);
		targetRect = new Rect(0.7f*screenWidth,0.07f*screenWidth,0.3f*screenWidth,0.05f*screenWidth);
		arrowRect = new Rect(0.7f*screenWidth,0.12f*screenWidth,0.3f*screenWidth,0.05f*screenWidth);
		timeRect = new Rect(screenWidth/2-0.06f*screenWidth,0.01f*screenWidth,0.15f*screenWidth,0.15f*screenWidth);
		levelRect = new Rect(0.03f*screenWidth,0.04f*screenWidth,0.2f*screenWidth,0.05f*screenWidth);
		powerRect = new Rect(0.03f*screenWidth,0.09f*screenWidth,0.2f*screenWidth,0.05f*screenWidth);
	}
	
	void OnGUI(){
		
		if(Screen.width > 900) {
			GUI.Label(scoreRect," Score:"+GameStatus.Inst.Score,scoreStyle_Large);
			GUI.Label(targetRect,"Target:"+GameStatus.Inst.TargetScore,scoreStyle_Large);
			GUI.Label(arrowRect," Arrow:"+GameStatus.Inst.ArrowCount,scoreStyle_Large);
			
			GUI.Label(timeRect,GameStatus.Inst.Time.ToString(),timeStyle_Large);
			GUI.Label(levelRect,"Level:"+(GameStatus.Level+1),scoreStyle_Large);
			GUI.Label(powerRect,"Power:"+Shoot.dragRange,scoreStyle_Large);
		}
		else if(Screen.width < 600) {
			GUI.Label(scoreRect," Score:"+GameStatus.Inst.Score,scoreStyle_Small);
			GUI.Label(targetRect,"Target:"+GameStatus.Inst.TargetScore,scoreStyle_Small);
			GUI.Label(arrowRect," Arrow:"+GameStatus.Inst.ArrowCount,scoreStyle_Small);
			
			GUI.Label(timeRect,GameStatus.Inst.Time.ToString(),timeStyle_Small);
			GUI.Label(levelRect,"Level:"+(GameStatus.Level+1),scoreStyle_Small);
			GUI.Label(powerRect,"Power:"+Shoot.dragRange,scoreStyle_Small);
		}
		else {
			GUI.Label(scoreRect," Score:"+GameStatus.Inst.Score,scoreStyle_Mid);
			GUI.Label(targetRect,"Target:"+GameStatus.Inst.TargetScore,scoreStyle_Mid);
			GUI.Label(arrowRect," Arrow:"+GameStatus.Inst.ArrowCount,scoreStyle_Mid);
			
			GUI.Label(timeRect,GameStatus.Inst.Time.ToString(),timeStyle_Mid);
			GUI.Label(levelRect,"Level:"+(GameStatus.Level+1),scoreStyle_Mid);
			GUI.Label(powerRect,"Power:"+Shoot.dragRange,scoreStyle_Mid);
		}
	}	
}
