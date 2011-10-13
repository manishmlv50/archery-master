using UnityEngine;
using System.Collections;

public class LightGroup : MonoBehaviour {
	
	private float intensity;
	public float Intensity{
		set{
			Object[] os = GameObject.FindObjectsOfType(typeof(Light));
			foreach(Object o in os){
				Light light = (Light) o;
				if(light.name.Equals("backgroudLight"))
				{	
					intensity = light.intensity;
					light.intensity = value;
				}
			}
			Invoke("back",DarknessTarget.DARK_TIME);
		}
	}
	
	void back() {
		Object[] os = GameObject.FindObjectsOfType(typeof(Light));
		foreach(Object o in os){
			Light light = (Light) o;
			if(light.name.Equals("backgroudLight"))
				light.intensity = intensity;
		}
	}
}
