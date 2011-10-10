using System;
using UnityEngine;

public class Database
{


	private static int[] _time = { 60, 60, 60 };
	private static int[] _targetScore = { 2000, 3500, 5000 };
	private static int[] _arrow = { 20, 25, 30 };

	public static int GetTime (int level)
	{
		return _time[level];
	}

	public static int ScoreOfTarget (Targets target)
	{
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
		return 1.8f;
	}

	public static Targets GetTarget (int level, int timeSpend, int pointID)
	{
			switch(levels._targetsLevel[level,timeSpend,pointID]) {
				case 1: return Targets.NormalTarget; 
				case 2: return Targets.BombTarget;
				case 3: return Targets.FreezeTarget;
				case 4: return Targets.TimeTarget;
				case 5 : return Targets.ProjectileTarget;
				case 6 : return Targets.WallTarget;
				case 7 : return Targets.StrongTarget;
				case 8 : return Targets.DarknessTarget;
				default : return Targets.Null;
			}
	}
	
	
}
