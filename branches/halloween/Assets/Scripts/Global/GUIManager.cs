using System;
using UnityEngine;
public class GUIManager
{
	private static Rect _scoreRect = new Rect(0.65f*Screen.width,0.04f*Screen.width,0.34f*Screen.width,0.05f*Screen.width);
	public static Rect ScoreRect
	{
		get{
			return _scoreRect;
		}
	}
	
	private static Rect _targetRect = new Rect(0.65f*Screen.width,0.09f*Screen.width,0.34f*Screen.width,0.05f*Screen.width);
	public static Rect TargetRect
	{
		get{
			return _targetRect;
		}
	}
	
	private static Rect _arrowRect = new Rect(0.65f*Screen.width,0.14f*Screen.width,0.34f*Screen.width,0.05f*Screen.width);
	public static Rect ArrowRect
	{
		get{
			return _arrowRect;
		}
	}
	
	private static Rect _timeRect = new Rect(Screen.width/2-0.06f*Screen.width,0.01f*Screen.width,0.15f*Screen.width,0.15f*Screen.width);
	public static Rect TimeRect
	{
		get{
			return _timeRect;
		}
	}
	
	private static Rect _levelRect = new Rect(0.03f*Screen.width,0.04f*Screen.width,0.2f*Screen.width,0.05f*Screen.width);
	public static Rect LevelRect
	{
		get{
			return _levelRect;
		}
	}
}

