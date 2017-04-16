﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void resetScoreBoard() {
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			PlayerPrefs.SetFloat (highScoreKey, 9999);
			PlayerPrefs.SetString (nameKey, "Unknown");
		}
	}

	public void load() {
		SceneManager.LoadScene (1);
	}
}
