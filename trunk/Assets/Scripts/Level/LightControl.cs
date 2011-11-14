using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
	
	private float intensity;
	public void TurnDark() {
		Object[] os = GameObject.FindObjectsOfType(typeof(Light));
		foreach(Object o in os){
			Light light = (Light) o;
			if(light.name.Equals("backgroudLight"))
			{	
				if(GameStatus.Level == 8)
					light.enabled = true;
				else
					light.enabled = false;
			}
			else if(light.name.Equals("light2"))
			{
				if(GameStatus.Level == 8)
					light.enabled = false;
				else
					light.enabled = true;
			}
		}
		Invoke("back",DarknessTarget.DARK_TIME);
	}
	
	void Start() {
		back();
	}
	
	void back() {
		Object[] os = GameObject.FindObjectsOfType(typeof(Light));
		foreach(Object o in os){
			Light light = (Light) o;
			if(light.name.Equals("backgroudLight")) {
				if(GameStatus.Level == 8)
					light.enabled = false;
				else
					light.enabled = true;
			}
			else if(light.name.Equals("light2"))
			{
				if(GameStatus.Level == 8)
					light.enabled = true;
				else
					light.enabled = false;
			}
		}
	}
}
