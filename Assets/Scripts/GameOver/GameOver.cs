using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		((TextMesh)GetComponent("TextMesh")).text = GameStatus.Inst.Score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
