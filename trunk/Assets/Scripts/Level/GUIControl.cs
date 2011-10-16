using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	
	public GUISkin skin;
	public GUIStyle timeStyle;
	
	void OnGUI(){
		GUI.skin = skin;
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
