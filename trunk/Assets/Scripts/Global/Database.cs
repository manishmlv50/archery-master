using System;

public class Database
{
	
	
	private static int [] _time = {60,60,64};
	private static int [] _targetScore = {800,1000,1500};
	private static int [] _arrow = {20,22,30};
	
	
	
	public static int GetTime(int level){
		return _time[level];
	}
	
	public static int ScoreOfTarget(Targets target){
		return 10;
	}
	
	public static int GetTargetScore(int level){
		return _targetScore[level];
	}
	
	public static int GetArrowCount(int level){
		return _arrow[level];
	}
	
	public static float GetMoveSpeed(){
		return 20;
	}
	
	public static float GetScoreBonus(){
		return 1;
	}
	
	public static float GetComboBonus(){
		return 1.8f;
	}
	
	public static Targets GetTarget(int level, int time, int pointID){
		if(pointID == 0)
		{
			if(time % 17==0)
				return Targets.TimeTarget;
			if(time % 12==0)
				return Targets.FreezeTarget;
			if(time % 15==0)
				return Targets.BombTarget;
			if(time % 5==0)
				return Targets.NormalTarget;
		}
		if(pointID == 1)
		{
			if(time % 13==0)
				return Targets.TimeTarget;
			if(time % 20==0)
				return Targets.FreezeTarget;
			if(time % 23==0)
				return Targets.BombTarget;
			if(time % 6==0)
				return Targets.NormalTarget;
		}
		if(pointID == 2)
		{
			if(time % 11==0)
				return Targets.TimeTarget;
			if(time % 16==0)
				return Targets.FreezeTarget;
			if(time % 22==0)
				return Targets.BombTarget;
			if(time % 7==0)
				return Targets.NormalTarget;
		}
		if(pointID == 3)
		{
			if(time % 23==0)
				return Targets.TimeTarget;
			if(time % 21==0)
				return Targets.FreezeTarget;
			if(time % 19==0)
				return Targets.BombTarget;
			if(time % 8==0)
				return Targets.NormalTarget;
		}
		return Targets.Null;
	}
}

