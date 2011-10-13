using System;
using UnityEngine;

public class Debug: MonoBehaviour
{
	public static bool DEBUG = true;
	
	private bool show = false;
	
	void OnGUI () {
		if(!DEBUG)
			return;
		
		if (GUI.Button (new Rect (0,0,Screen.width/10,Screen.height/20), "Debug")) {
			show = !show;
		}
		
		if(show){
			GUI.Box(new Rect(Screen.width*0.25f, Screen.height*0.2f,Screen.width*0.5f,Screen.height*0.6f),"Debug");
			Rect rect =new Rect(Screen.width*0.3f, Screen.height*0.36f,Screen.width*0.15f,Screen.height*0.06f);
			GameStatus.Inst.MoveSpeed = LabelSlider (rect, GameStatus.Inst.MoveSpeed, 10,30, "Move Speed:");
			rect.y+=rect.height*2;
			GameStatus.Inst.ScoreBonus = LabelSlider (rect, GameStatus.Inst.ScoreBonus, 1,3f, "Score Bonus:");
			rect.y+=rect.height*2;
			GameStatus.Inst.ComboBonus = LabelSlider (rect, GameStatus.Inst.ComboBonus, 1.5f,2, "Combo Bonus:");
			rect.y+=rect.height*2;
		}
			
	}
	
	float LabelSlider (Rect screenRect, float sliderValue, float sliderMinValue,float sliderMaxValue,String labelText)
	{
		GUI.Label (screenRect, labelText);
		screenRect.x += screenRect.width; 
		screenRect.y += 5;
		screenRect.width *=1.5f;
		sliderValue = GUI.HorizontalSlider(screenRect, sliderValue,sliderMinValue, sliderMaxValue);
		screenRect.x += screenRect.width+10;
		screenRect.y -= 5;
		screenRect.width /=1.5f;
		GUI.Label (screenRect, sliderValue.ToString());
		return sliderValue;
	}
}


