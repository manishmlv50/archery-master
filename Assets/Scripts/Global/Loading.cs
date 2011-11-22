using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	
	public GUIStyle style_large;
	public GUIStyle style_small;
	
	public static AsyncOperation LOAD = null;
	public static int guiDepth = 0;
	
	// Use this for initialization
	void Start () {
		LOAD = null;
		guiDepth = 0;
	}
	
	void OnGUI() {
		GUI.depth = guiDepth;
		GUIStyle loadStyle;
		if(Screen.width > 900) {
			loadStyle = style_large;
		}
		else {
			loadStyle = style_small;
		}
		
		// if loading the other level, then pop up a message of "Loading.....%"
		if(LOAD != null) {	
			loadStyle.alignment = TextAnchor.MiddleCenter;
			//GUI.Box(new Rect(0.2f*Screen.width, 0.4f*Screen.height, 0.6f*Screen.width, 0.2f*Screen.height),
		    //	    "Loading..." + (LOAD.progress*100).ToString() + "%", loadStyle);
			GUI.Box(new Rect(0.2f*Screen.width, 0.4f*Screen.height, 0.6f*Screen.width, 0.2f*Screen.height),
		    	    "Loading...", loadStyle);
		}
	}
}
