using System;
using UnityEngine;

public class Debug: MonoBehaviour
{
	public static bool DEBUG = true;
	public GUISkin skin_large;
	public GUISkin skin_small;
	private bool show = false;
	
	void OnGUI () {
		if(!DEBUG)
			return;
		
		if(Screen.width > 900) {
			GUI.skin = skin_large;
		}
		else {
			GUI.skin = skin_small;
		}
		
		if (GUI.Button (new Rect (5,5,Screen.width/10,Screen.height/20), "Debug")) {
			show = !show;
			Time.timeScale = 1-Time.timeScale;
		}
		
		if(show){
			GUI.BeginGroup(new Rect(0.2f*Screen.width, 0.1f*Screen.height, 0.6f*Screen.width, 0.8f*Screen.height));
			GUI.Box(new Rect(0, 0, 0.6f*Screen.width, 0.8f*Screen.height), "DEBUG");
			Rect rect =new Rect(0.04f*Screen.width, 0.27f*Screen.height, Screen.width*0.2f,Screen.height*0.06f);
			GameStatus.Inst.MoveSpeed = LabelSlider (rect, GameStatus.Inst.MoveSpeed, 10,30, "Move Speed");
			rect.y+=rect.height*2;
			GameStatus.Inst.ScoreBonus = LabelSlider (rect, GameStatus.Inst.ScoreBonus, 1,3f, "Score Bonus");
			rect.y+=rect.height*2;
			GameStatus.Inst.ComboBonus = LabelSlider (rect, GameStatus.Inst.ComboBonus, 1.5f,2, "Combo Bonus");
			rect.y +=rect.height*2f;
			rect.x += Screen.width*0.3f;
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
		screenRect.x += screenRect.width + (10f*Screen.width/960f); 
		screenRect.y += 5f*Screen.height/640f;
		screenRect.width *= 1.2f;
		sliderValue = GUI.HorizontalSlider(screenRect, sliderValue,sliderMinValue, sliderMaxValue);
		screenRect.x += screenRect.width + (10f*Screen.width/960f);
		screenRect.y -= 5f*Screen.height/640f;
		screenRect.width /= 4f;
		GUI.TextArea (screenRect, String.Format("{0:0.00}",sliderValue));
		return sliderValue;
	}
}


