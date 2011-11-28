using UnityEngine;
using System.Collections;

public class ChooseLevelSetUp : MonoBehaviour {

	// Use this for initialization
	int i;
	void Awake(){

		
		
	}
	void Start () {
		
		
		
		
		
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	void GoBack()
	{
		Application.LoadLevel("StartMenu");
	}
	
	
	
	void OnGUI(){
		if(GUILayout.Button("Reset Level"))
		{
			PlayerPrefs.SetInt("GameProgress",0);
			for(i = 0 ; i < 9; i++)
			{
				PlayerPrefs.SetInt("Level"+i + "High",0);
			}
			
			Application.LoadLevel("LevelSelection");
		}
	
	}
}
