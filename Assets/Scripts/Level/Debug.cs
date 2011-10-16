using System;
using UnityEngine;

public class Debug: MonoBehaviour
{
	public static bool DEBUG = true;
	public GUISkin skin;
	private bool show = false;
	
	void OnGUI () {
		if(!DEBUG)
			return;
		GUI.skin = skin;
		if (GUI.Button (new Rect (5,5,Screen.width/10,Screen.height/20), "Debug")) {
			show = !show;
			Time.timeScale = 1-Time.timeScale;
		}
		
		if(show){
			GUI.BeginGroup(new Rect((Screen.width-512)/2, (Screen.height-512)/2,512,512));
			GUI.Box(new Rect(0, 0,512,512),"DEBUG");
			Rect rect =new Rect(68, 210,Screen.width*0.15f,Screen.height*0.06f);
			GameStatus.Inst.MoveSpeed = LabelSlider (rect, GameStatus.Inst.MoveSpeed, 10,30, "Move Speed");
			rect.y+=rect.height*2;
			GameStatus.Inst.ScoreBonus = LabelSlider (rect, GameStatus.Inst.ScoreBonus, 1,3f, "Score Bonus");
			rect.y+=rect.height*2;
			GameStatus.Inst.ComboBonus = LabelSlider (rect, GameStatus.Inst.ComboBonus, 1.5f,2, "Combo Bonus");
			rect.y +=rect.height*1.5f;
			rect.x += 250;
			if(GUI.Button(rect,"Back"))
			{
				show = !show;
				Time.timeScale = 1-Time.timeScale;
			}
			GUI.EndGroup();
		}
			
	}
	
	float LabelSlider (Rect screenRect, float sliderValue, float sliderMinValue,float sliderMaxValue,String labelText)
	{
		GUI.Label (screenRect, labelText);
		screenRect.x += screenRect.width+10; 
		screenRect.y += 5;
		screenRect.width *=1.2f;
		sliderValue = GUI.HorizontalSlider(screenRect, sliderValue,sliderMinValue, sliderMaxValue);
		screenRect.x += screenRect.width+10;
		screenRect.y -= 5;
		screenRect.width /=4f;
		GUI.TextArea (screenRect, String.Format("{0:0.00}",sliderValue));
		return sliderValue;
	}
}


