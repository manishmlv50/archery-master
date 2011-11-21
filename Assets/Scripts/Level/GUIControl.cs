using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	
	public GUISkin skin_large;
	public GUISkin skin_small;	
	public GUIStyle timeStyle_large;
	public GUIStyle timeStyle_small;
	public SpriteText DisplayScore;
	public SpriteText DisplayArrow;
	public SpriteText DisplayLevel;
	public SpriteText DisplayTime;
	
	private GUIStyle timeStyle;
	
	void OnGUI(){
		audio.volume = GameStatus.BGM;
		if(Screen.width > 900) {
			GUI.skin = skin_large;
			timeStyle = timeStyle_large;
		}
		else {
			GUI.skin = skin_small;
			timeStyle = timeStyle_small;
		}
		
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;

		if(e != null && Character.Inst.Super)
			DisplayArrow.Text = "Arrow: MAX";
		else
			DisplayArrow.Text = "Arrow: " + GameStatus.Inst.ArrowCount;
		
		DisplayScore.Text = "Score:  " + GameStatus.Inst.Score;
		
		DisplayLevel.Text = "Level " + (GameStatus.Level + 1);
		
		DisplayTime.Text = GameStatus.Inst.Time.ToString();
	
		
		
/*
		GUI.Label(GUIManager.ScoreRect," Score:"+GameStatus.Inst.Score);
		GUI.Label(GUIManager.TargetRect,"Target:"+GameStatus.Inst.TargetScore);
		
		
		
		if(e != null && Character.Inst.Super)
			GUI.Label(GUIManager.ArrowRect," Arrow:Max");
		else
			GUI.Label(GUIManager.ArrowRect," Arrow:"+GameStatus.Inst.ArrowCount);
	*/		
		
		//GUI.Label(GUIManager.TimeRect,GameStatus.Inst.Time.ToString(),timeStyle);
		//GUI.Label(GUIManager.LevelRect,"Level:"+(GameStatus.Level+1));
		

		
		
		
		
		
	}	
}
