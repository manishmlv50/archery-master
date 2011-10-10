using UnityEngine;
using System.Collections;

public class LightGroup : MonoBehaviour {
	
	private float intensity;
	public float Intensity{
		set{
			Object[] os = GameObject.FindObjectsOfType(typeof(Light));
			foreach(Object o in os){
				Light light = (Light) o;
				intensity = light.intensity;
				light.intensity = value;
			}
			Invoke("back",DarknessTarget.DARK_TIME);
		}
	}
	
	void back() {
		Object[] os = GameObject.FindObjectsOfType(typeof(Light));
		foreach(Object o in os){
			Light light = (Light) o;
			light.intensity = intensity;
		}
	}
}
