using System;
using System.Collections;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
	public struct Report
	{
		public int score;
		public int maxCombo;
		public int arrowLeft;
	}
	
	public static Report report = new Report();
	public static float soundVol = 0.6f;
	public static float BGM = 0.6f;
	public static bool tilting = false;
	public static int Level { get;set;}
	
	private static GameStatus _inst;
	public static GameStatus Inst
	{	
		get{
			return _inst;
		}		
	}
	
	
	
	
	public float ScoreBonus{get;set;}
	public float ComboBonus{get;set;}
	public float MoveSpeed{get;set;}
	public int Score{get;set;}
	public int TargetScore{get;set;}
	
	private int _arrowCount;
	public int ArrowCount{
		get
		{
			return _arrowCount;
		}
		set
		{
			_arrowCount = value;
			if(_arrowCount <= 0)
			{
				Invoke ("endLevel", 0.5f);
			}
		}
	}
	
	
	
	private int _hp;
	public int HP{
		get
		{
			return _hp;
		}
		set
		{
			_hp = value;
			if(_hp <= 0){
				endLevel();
			}
		}
	}
	
	
	private int _time;
	public int Time{
		get
		{
			return _time;
		}
		set
		{
			_time = value;
			if(_time <= 0)
				endLevel();
		}
	}
	
	private int _totalTime;
	public int TimeSpend{
		get
		{
			return _totalTime - _time;
		}
	}
	
	void Start(){
		_inst = this;
			
		_totalTime = Database.GetTime (GameStatus.Level);
		_time = Database.GetTime (GameStatus.Level);
		TargetScore = Database.GetTargetScore (GameStatus.Level);
		Score = 0;
		ArrowCount = Database.GetArrowCount (GameStatus.Level);
		MoveSpeed = Database.GetMoveSpeed ();
		ScoreBonus = Database.GetScoreBonus ();
		ComboBonus = Database.GetComboBonus ();
		HP = Database.GetHP(GameStatus.Level);
	}
	
	public void IncreaseTime(int time)
	{
		Time += time;
		_totalTime += time;
	}
	
	public void EarnScore(int combo,Targets targetId)
	{
		Debug.Log("Destroy taget:"+targetId);
		Score += (int)(Database.ScoreOfTarget(targetId) * 
		                          Mathf.Pow(ComboBonus,combo) *
		                          ScoreBonus);
	}
	
	private void endLevel ()
	{
		report.score = Score;
		if (Score >= TargetScore) {
			Application.LoadLevel ("Statistic");
		} else {
			Application.LoadLevel ("GameOver");
		}
	}


}

