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
		if(time % (pointID+2) == 0)
		{
			if(time % (pointID+4)==0)
				return Targets.TimeTarget;
			if(time % (pointID+5)==0)
				return Targets.FreezeTarget;
			if(time % (pointID+6)==0)
				return Targets.BombTarget;
			return Targets.NormalTarget;
		}
		return Targets.Null;
	}
}

