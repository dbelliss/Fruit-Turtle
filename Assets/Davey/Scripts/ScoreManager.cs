﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public GameObject scoreBoard;
	public GameObject inp;
	public GameObject restart;
	public GameObject highScoreText;
	int currentHigh;
	int currentLow;

	void Start() {
		string highScoreKey = "HighScore"+(0+1).ToString();
		currentHigh = PlayerPrefs.GetInt (highScoreKey,0);
		currentLow = PlayerPrefs.GetInt ("HighScore6",0);
		highScoreText.GetComponent<Text> ().text = "High Scrore: " + currentHigh.ToString ();;
	}

	public void endGame() {
		printHighScores ();
		if (currentLow > GameManager.GetCurrentPoints ()) { 
			inp.SetActive (true);
		} else
			restart.SetActive (true);
			
	}

	public void updateScoreBoard() {
		string name = GameObject.FindWithTag ("NameInput2").GetComponent<Text> ().text;
		Debug.Log (name);
		inp.SetActive (false);
		Text highScoresText = scoreBoard.GetComponent<Text> ();
		int[] highScores = new int[5];
		int score = (int)Time.timeSinceLevelLoad;
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			int highScore = PlayerPrefs.GetInt(highScoreKey,0);
			if(score < highScore){
				int temp = highScore;
				PlayerPrefs.SetInt (highScoreKey, score);
				PlayerPrefs.SetString (nameKey, name);
				score = temp;
			}
		}
		printHighScores ();
	}

	public void resetScoreBoard() {
		Text highScoresText = scoreBoard.GetComponent<Text> ();

		int[] highScores = new int[5];
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			PlayerPrefs.SetInt (highScoreKey, 9999);
			PlayerPrefs.SetString (nameKey, "Unknown");
		}
	}

	public void printHighScores() {
		inp.SetActive (false);
		Text highScoresText = scoreBoard.GetComponent<Text> ();
		highScoresText.text = "High Scores: \n";
		scoreBoard.SetActive (true);
		int[] highScores = new int[5];
		for (int i= 0; i < highScores.Length; i++){

			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			int highScore = PlayerPrefs.GetInt(highScoreKey,0);
			string name = PlayerPrefs.GetString (nameKey, "none");
			highScoresText.text += ((i + 1).ToString() + ": " + name.ToString() + " " 
				+ highScore.ToString() + " seconds\n");
		}
		restart.SetActive(true);
	}
}
