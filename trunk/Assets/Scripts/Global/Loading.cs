using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	
	private float percentageLoaded = 0;
	
	public static bool LOAD = false;
	public static int guiDepth = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		GUI.depth = guiDepth;
		
		// if loading the other level, then pop up a message of "Loading.....%"
		if(LOAD) {
			GUIStyle loadStyle = new GUIStyle(GUI.skin.box);
			GUI.skin.box.fontSize = 22 * Screen.height/640;
			percentageLoaded = Application.GetStreamProgressForLevel("Level") * 100;
			GUI.Box(new Rect(0.4f*Screen.width, 0.4f*Screen.height, 180*Screen.width/960, 40*Screen.height/640),
		    	    "Loading..." + percentageLoaded.ToString() + "%", loadStyle);
		}
	}
}
