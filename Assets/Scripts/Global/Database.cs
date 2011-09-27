using System;
using UnityEngine;

public class Database
{
	
	
	private static int [] _time = {60,60,64};
	private static int [] _targetScore = {800,1000,1500};
	private static int [] _arrow = {20,22,30};
	
	// 1:normalTarget; 2:timeTarget; 3:bombTarget; 4:freezeTarget
	// rows of the array are seconds,column of the array are pointID
	 private static int [,] _targetsSeq1 = 
	 {{1,0,0,0},{0,1,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,0}};
	
	
	
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
//	}
		
	}
}

