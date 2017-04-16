using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public GameObject scoreBoard;
	public GameObject inp;

	public void endGame() {
		inp.SetActive (true);
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
			highScoresText.text += (i.ToString() + ": " + name.ToString() + " " 
				+ highScore.ToString() + " seconds\n");
		}
	}
}
