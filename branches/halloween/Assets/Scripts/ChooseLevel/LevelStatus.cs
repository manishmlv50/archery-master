using UnityEngine;
using System.Collections;

public class LevelStatus : MonoBehaviour {
	public int levelNum;
	public ChooseLevelSetUp chooseLevelSetUp;
	public int levelStatus;
	public int TargetScore;
	public int HighScore;
	public Vector3 Origin;
	public Vector3 Hide;
	// Use this for initialization
	void Start () {
		
		Origin= transform.position;
		Hide = new Vector3(0,1000,0);
		TargetScore = Database.GetTargetScore (levelNum);
		HighScore = PlayerPrefs.GetInt("Level" + levelNum + "High");
		
		
		transform.FindChild("Level Num").GetComponent<SpriteText>().Text = "" + (levelNum+1);
		
		
		foreach(Transform child in transform)
		{
			if(child.name != "Locked" && child.name != "Level Num")
				child.transform.position = Hide;
		}
		
		
		
		
		
		if(levelNum <= PlayerPrefs.GetInt("GameProgress"))
		{
			transform.FindChild("Locked").transform.position = Hide;
			
			if(HighScore >= TargetScore && HighScore < TargetScore + 500)
			{
				transform.FindChild("1 Star").position = Origin;
			}else if(HighScore >=TargetScore + 500 && HighScore < TargetScore + 1000)
			{
				transform.FindChild("2 Star").position = Origin;
			}else if(HighScore >= TargetScore +1000)
			{
				transform.FindChild("3 Star").position = Origin;
			}else
			{
				transform.FindChild("0 Star").position = Origin;
			}
			
			
			
			
			
		}else
		{

		}
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void loadGame(){
		GameStatus.Level = levelNum;
		print("GameStatus: " + GameStatus.Level);
		Application.LoadLevel("Level");
	}
}
