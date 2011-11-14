using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightControl : MonoBehaviour {
	
	private float intensity;
	private bool enableLight;
	public Material black;
	private static Dictionary<GameObject,Material> materialBackup = new Dictionary<GameObject,Material>();
	private void switchLight()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("BackgroundLight");
		foreach(GameObject light in go){
			if(GameStatus.Level == 8)
				light.light.enabled = !enableLight;
			else
				light.light.enabled = enableLight;
		}
		go = GameObject.FindGameObjectsWithTag("FrontLight");
		foreach(GameObject light in go){
			if(GameStatus.Level == 8)
				light.light.enabled = enableLight;
			else
				light.light.enabled = !enableLight;
		}
		
		go = GameObject.FindGameObjectsWithTag("Background");
		foreach(GameObject gb in go){
			if(enableLight)
			{
				Material m = null;
				if(materialBackup.TryGetValue(gb,out m))
					gb.renderer.material = m;
			}
			else{
				materialBackup[gb] = gb.renderer.material;
				gb.renderer.material = black;
			}
		}
	}
	public void TurnDark() {
		enableLight = false;
		switchLight();
		enableLight = true;
		Invoke("switchLight",DarknessTarget.DARK_TIME);
	}
	
	void Start() {
		enableLight = true;
		switchLight();
	}
}
