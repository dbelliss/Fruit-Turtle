using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public GameObject scoreBoard;
	public GameObject inp;
	public GameObject restart;
	public GameObject highScoreText;
	private float finalScore;
	float currentHigh;
	float currentLow;

	void Start() {
		string highScoreKey = "HighScore"+(0+1).ToString();
		currentHigh = PlayerPrefs.GetFloat (highScoreKey,0);
		currentLow = PlayerPrefs.GetFloat ("HighScore5",0);
		Debug.Log("LOW:" + currentLow.ToString());
		highScoreText.GetComponent<Text> ().text = "High Score: " + currentHigh.ToString ();;
	}

	public void endGame() {
		finalScore = Time.timeSinceLevelLoad;
		printHighScores ();

		if (currentLow > finalScore) { 
			inp.SetActive (true);
		} else
			restart.SetActive (true);
			
	}

	public void updateScoreBoard() {
		string name = GameObject.FindWithTag ("NameInput2").GetComponent<Text> ().text;
		Debug.Log (name);
		inp.SetActive (false);
		float[] highScores = new float[5];
		float score = finalScore;
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			float highScore = PlayerPrefs.GetFloat(highScoreKey,0f); 
			string namescore = PlayerPrefs.GetString(nameKey);
			if(score < highScore){
				float temp = highScore;
				string stemp = namescore;
				PlayerPrefs.SetFloat (highScoreKey, score);
				PlayerPrefs.SetString (nameKey, name);
				score = temp;
				name = stemp;
			}
		}
		printHighScores ();
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

	public void printHighScores() {
		inp.SetActive (false);
		Text highScoresText = scoreBoard.GetComponent<Text> ();
		highScoresText.text = "High Scores: \n";
		scoreBoard.SetActive (true);
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){

			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			float highScore = PlayerPrefs.GetFloat(highScoreKey,0);
			string name = PlayerPrefs.GetString (nameKey, "none");
			highScoresText.text += ((i + 1).ToString() + ": " + name.ToString() + " " 
				+ highScore.ToString() + " seconds\n");
		}
		restart.SetActive(true);
	}
}
