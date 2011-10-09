using System;
using UnityEngine;

public class Database
{


	private static int[] _time = { 60, 60, 60 };
	private static int[] _targetScore = { 2000, 3500, 5000 };
	private static int[] _arrow = { 20, 25, 30 };

	// 1:normalTarget; 2:timeTarget; 3:bombTarget; 4:freezeTarget
	// rows of the array are seconds,column of the array are pointID
	//private static int[,] _targetsSeq1 = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } };



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

	/*public static Targets GetTarget(int level, int time, int pointID){
		Debug.print(time+" "+pointID);
		
		//if(level == 1) {
			switch (_targetsSeq1[60-time,pointID]) {   
			case 1: 
				return Targets.NormalTarget;
			Debug.print("shoot");
				break;	
			case 2: 
				return Targets.TimeTarget; 
				break;	
			case 3: 
				return Targets.BombTarget; 
				break;	
			case 4: 
				return Targets.FreezeTarget; 
				break;
			default:
				return Targets.Null;
			}
//		} else if(level == 2) {    make seq2 & seq3 later
//			switch (_targetsSeq2[60-time,pointID]) {   
//			case 1: 
//				return Targets.NormalTarget; 
//				break;	
//			case 2: 
//				return Targets.TimeTarget; 
//				break;	
//			case 3: 
//				return Targets.BombTarget; 
//				break;	
//			case 4: 
//				return Targets.FreezeTarget; 
//				break;
//			default:
//				return Targets.Null;
//			}
//		} else if(level == 3) {
//			switch (_targetsSeq3[60-time,pointID]) {   
//			case 1: 
//				return Targets.NormalTarget; 
//				break;	
//			case 2: 
//				return Targets.TimeTarget; 
//				break;	
//			case 3: 
//				return Targets.BombTarget; 
//				break;	
//			case 4: 
//				return Targets.FreezeTarget; 
//				break;
//			default:
//				return Targets.Null;
//			}
//	}*/

	public static Targets GetTarget (int level, int timeSpend, int pointID)
	{
		if (pointID == 0) {
			if (timeSpend % 5 == 0)
				return Targets.NormalTarget;
			if (timeSpend % 12 == 0)
				return Targets.FreezeTarget;
			if (timeSpend % 13 == 0)
				return Targets.BombTarget;
			if (timeSpend % 29 == 0)
				return Targets.TimeTarget;
			if (timeSpend % 7 == 0)
				return Targets.ProjectileTarget;
			if (timeSpend % 19 == 0)
				return Targets.WallTarget;
			if (timeSpend % 11 == 0)
				return Targets.StrongTarget;
			
		}
		if (pointID == 1) {
			if (timeSpend % 6 == 0)
				return Targets.NormalTarget;
			if (timeSpend % 13 == 0)
				return Targets.FreezeTarget;
			if (timeSpend % 23 == 0)
				return Targets.BombTarget;
			//if (timeSpend % 42 == 0)
			//	return Targets.TimeTarget;
			
			
		}
		if (pointID == 2) {
			if (timeSpend % 3 == 0)
				return Targets.NormalTarget;
			if (timeSpend % 13 == 0)
				return Targets.FreezeTarget;
			if (timeSpend % 22 == 0)
				return Targets.BombTarget;
			if (timeSpend % 37 == 0)
				return Targets.TimeTarget;
			
			
		}
		if (pointID == 3) {
			if (timeSpend % 4 == 0)
				return Targets.NormalTarget;
			if (timeSpend % 21 == 0)
				return Targets.FreezeTarget;
			if (timeSpend % 19 == 0)
				return Targets.BombTarget;
			if (timeSpend % 51 == 0)
				return Targets.TimeTarget;
			
			
		}
		return Targets.Null;
	}
	
	
}

