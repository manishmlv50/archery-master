using System;
using UnityEngine;

public class Database
{


	private static int[] _time = { 40, 70, 60, 60, 65, 70, 70, 80, 80 };
	private static int[] _targetScore = { 500, 700, 2000, 2500, 5000, 3200, 6000, 7000, 6500 };
	private static int[] _arrow = { 15, 15, 15, 15, 13, 15, 20, 20, 20 };

	public static int GetTime (int level)
	{
		return _time[level];
	}
	
	public static int GetHP(int level)
	{
		return 10;
	}

	public static int ScoreOfTarget (Targets target)
	{
		if(target == Targets.NormalTarget)
			return 10;
		else if(target == Targets.BombTarget)
			return 15;
		else if(target == Targets.StrongTarget)
			return 25;
		else if(target == Targets.ProjectileTarget)
			return 15;
		else if(target == Targets.TimeTarget)
			return 15;
		else if(target == Targets.WallTarget)
			return 50;
		else
			return 10;
	}

	public static int GetTargetScore (int level)
	{
		return _targetScore[level];
	}

	public static int GetArrowCount (int level)
	{
		return _arrow[level];
	}

	public static float GetMoveSpeed ()
	{
		return 20;
	}

	public static float GetScoreBonus ()
	{
		return 1;
	}

	public static float GetComboBonus ()
	{
		return 1.6f;
	}
	
	
	
	public static int GetTargetSpeed(int level, int timeSpend, int pointID)
	{
		return LevelsSpeed._targetsSpeed[level,timeSpend,pointID];
	}

	public static Targets GetTarget (int level, int timeSpend, int pointID)
	{
		if(level >= Levels._targetsLevel.GetLength(0))
			return Targets.Null;
		
		if(timeSpend >= Levels._targetsLevel.GetLength(1))
			return Targets.Null;
		
		switch(Levels._targetsLevel[level,timeSpend,pointID]) {
				case 1: return Targets.NormalTarget; 
				case 2: return Targets.BombTarget;
				case 3: return Targets.FreezeTarget;
				case 4: return Targets.TimeTarget;
				case 5 : return Targets.ProjectileTarget;
				case 6 : return Targets.WallTarget;
				case 7 : return Targets.StrongTarget;
				case 8 : return Targets.DarknessTarget;
				case 9 : return Targets.ReflectorTarget;
				default : return Targets.Null;
			}
	}
	
	
}

