using System;
using System.Collections;
using UnityEngine;

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
	
	private int _time;
	private int _totalTime;
	public float ScoreBonus{get;set;}
	public float ComboBonus{get;set;}
	public float MoveSpeed{get;set;}
	public int Score{get;set;}
	public int ArrowCount{get;set;}
	public int TargetScore{get;set;}
	
	public int Time{
		get
		{
			return _time;
		}
	}
	
	public int TimeSpend{
		get
		{
			return _totalTime - _time;
		}
	}
	
	public static float soundVol = 0.6f;
	public static float BGM = 0.6f;
	public static bool tilting = false;
	
	public static GameStatus Inst
	{	
		get{
			return _inst;
		}		
	}
	
	public GameStatus(int time,int targetScore, int arrowCount, float moveSpeed, float scoreBonus, float comboBonus){
		_inst = this;
		_totalTime = time;
		_time = time;
		TargetScore = targetScore;
		
		Score = 0;
		ArrowCount = arrowCount;
		MoveSpeed = moveSpeed;
		ScoreBonus = scoreBonus;
		ComboBonus = comboBonus;
	}
	
	public void Tick(){
		_time -- ;
	}
	
	public void IncreaseTime(int time)
	{
		_time += time;
		_totalTime += time;
	}
	
	public void EarnScore(int combo,Targets targetId)
	{
		Score += (int)(Database.ScoreOfTarget(targetId) * 
		                          Mathf.Pow(ComboBonus,combo) *
		                          ScoreBonus);
	}

}

