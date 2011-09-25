using System;
using UnityEngine;

public class Debug: MonoBehaviour
{
	void Start(){
		new GameStatus(Database.GetTime(GameStatus.Level),
			                       Database.GetTargetScore(GameStatus.Level),
			                       Database.GetArrowCount(GameStatus.Level),
			                       Database.GetMoveSpeed(),
			                       Database.GetScoreBonus(),
			                       Database.GetComboBonus());
		InvokeRepeating("countDown",1,1);
	}
	
	private bool show = false;
	void OnGUI () {
		if (GUI.Button (new Rect (0,0,50,20), "Debug")) {
			show = !show;
		}
		
		if(show){
			GUI.Box(new Rect(Screen.width/2-150, Screen.height/2-160,300,320),"Debug");
			Rect rect =new Rect(Screen.width/2-120, Screen.height/2-120,80,20);
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
	
	private void countDown(){
		if(GameStatus.Inst.Time == 0){
			if(GameStatus.Inst.Score >= GameStatus.Inst.TargetScore){
				Application.LoadLevel("Statistic");
			}
			else{
				Application.LoadLevel("GameOver");
			}
		}
		else{
			GameStatus.Inst.Time--;
		}
	}
}


