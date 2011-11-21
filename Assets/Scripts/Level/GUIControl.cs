using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	public SpriteText DisplayScore;
	public SpriteText DisplayArrow;
	public SpriteText DisplayLevel;
	public SpriteText DisplayTime;
	
	void Update(){

		Energy e = FindObjectOfType(typeof(Energy)) as Energy;

		if(e != null && Character.Inst.Super)
			DisplayArrow.Text = "Arrow: MAX";
		else
			DisplayArrow.Text = "Arrow: " + GameStatus.Inst.ArrowCount;
		
		DisplayScore.Text = "Score:  " + GameStatus.Inst.Score;
		
		DisplayLevel.Text = "Level " + (GameStatus.Level + 1);
		
		DisplayTime.Text = GameStatus.Inst.Time.ToString();
	

		
		
		
		
	}	
}
