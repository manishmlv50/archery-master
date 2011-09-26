using System;


public class GameStatus
{
	private static GameStatus _inst;
	private static int _currentLevel = 0;
	public static int Level {
		get{
			return _currentLevel;
		}
		set{
			_currentLevel = value;
		}
	}
	
	public float ScoreBonus{get;set;}
	public float ComboBonus{get;set;}
	public float MoveSpeed{get;set;}
	public int Score{get;set;}
	public float ArrowCount{get;set;}
	public float TargetScore{get;set;}
	public float Time{get;set;}
	
	public static GameStatus Inst
	{	
		get{
			return _inst;
		}		
	}
	
	public GameStatus(float time,float targetScore, float arrowCount, float moveSpeed, float scoreBonus, float comboBonus){
		_inst = this;
		Time = time;
		TargetScore = targetScore;
		
		Score = 0;
		ArrowCount = arrowCount;
		MoveSpeed = moveSpeed;
		ScoreBonus = scoreBonus;
		ComboBonus = comboBonus;
	}
	
	public void earnScore(int combo,int targetId)
	{
		Score += (int)(Database.HitTarget(targetId) * 
		                          Mathf.Pow(ComboBonus,combo) *
		                          ScoreBonus);
	}
}

