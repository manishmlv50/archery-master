using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	
	public GUISkin skin_large;
	public GUISkin skin_small;	
	public GUIStyle timeStyle_large;
	public GUIStyle timeStyle_small;
	
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
		
		GUI.Label(GUIManager.ScoreRect," Score:"+GameStatus.Inst.Score);
		GUI.Label(GUIManager.TargetRect,"Target:"+GameStatus.Inst.TargetScore);
			
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e != null && e.super_mode)
			GUI.Label(GUIManager.ArrowRect," Arrow:Max");
		else
			GUI.Label(GUIManager.ArrowRect," Arrow:"+GameStatus.Inst.ArrowCount);
			
		GUI.Label(GUIManager.TimeRect,GameStatus.Inst.Time.ToString(),timeStyle);
		GUI.Label(GUIManager.LevelRect,"Level:"+(GameStatus.Level+1));
	}	
}
