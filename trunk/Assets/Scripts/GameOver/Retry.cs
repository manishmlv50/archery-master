using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		guiTexture.pixelInset = new Rect(0.97f*screenWidth-guiTexture.pixelInset.width,
		                                 0.25f*screenHeight-guiTexture.pixelInset.height,
		                                 guiTexture.pixelInset.width,
		                                 guiTexture.pixelInset.height);
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch currentTouch in Input.touches){
			if(currentTouch.phase == TouchPhase.Ended && guiTexture.HitTest(currentTouch.position)){
				Application.LoadLevel("Level");
			}
		}
	}
}
