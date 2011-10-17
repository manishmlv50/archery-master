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
				//intensity = light.intensity;
				light.enabled = false;
			}
			else if(light.name.Equals("light2"))
			{
				//intensity = light.intensity;
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
			if(light.name.Equals("backgroudLight"))
				//light.intensity = intensity;
				light.enabled = true;
			else if(light.name.Equals("light2"))
			{
				//intensity = light.intensity;
				light.enabled = false;
			}
		}
	}
}
