using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	public bool lvlDone;
	public string highScore; 
	public int score; 
	public int tempScore;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelDone(){
		lvlDone = true; 
		score = 100000;
		for (int i = 0; i < 10; i++){
			if(PlayerPrefs.GetInt("highScore" + i) < score){
				tempScore = PlayerPrefs.GetInt("highScore" + i);
				PlayerPrefs.SetInt("highScore" + i, score);
				if(i < 10){
					int j = i + 1; 
					PlayerPrefs.SetInt("highScore" + j, tempScore);
				}
			}
		}
	}

	void OnGui(){
		if(lvlDone){
			for (int i = 0; i < 10; i++){
				GUI.Box(new Rect(100, 75*i, 150, 50), "Pos " + i + "." + PlayerPrefs.GetInt("highScore" + i));
			}
		}
	}
}
