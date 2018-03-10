using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; // Enum

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance; // Singleton instance

	[SerializeField]
	private GameObject scoreBoard;

	[SerializeField]
	private GameObject inp;

	[SerializeField]
	private GameObject restartButton;

	[SerializeField]
	private GameObject highScoreText;

	[SerializeField]
	private Text inputFieldText;

	float currentHigh; // Stores the best score
	float currentLow; // Stores the lowest score to beat to get a high score

	private string highScoreKey = string.Empty;

	void Awake() {
		if (instance != null) {
			Debug.LogError ("Error: two GameManagers were created");
			return;
		} 

		if (scoreBoard == null || inp == null || highScoreText == null
			|| inputFieldText == null) {
			Debug.LogError("Error: Score manager has an unset variable");
		}
		instance = this;
	}

	void Start() {
		Debug.Log ("Game mode is " + GameManager.instance.curGameMode);
		highScoreKey = "HighScore" + GameManager.instance.curGameMode.ToString ();
		currentHigh = PlayerPrefs.GetInt (highScoreKey + "1",0); // Get first on highscore list for this gamemode
		currentLow = PlayerPrefs.GetInt (highScoreKey + "5",0);
		highScoreText.GetComponent<Text> ().text = "High Score: " + currentHigh.ToString ();;
	}

	public void EndGame() {
		int finalScore = GameManager.instance.curPoints;
		printHighScores ();
		if (currentLow < finalScore) { 
			// Allow input of new high score name
			inp.SetActive (true);
		} 
		else
		{
			// Show restart information
			#if !(UNITY_IOS || UNITY_ANDROID)
			// Only show restart info if not on phone
			restartText.SetActive (true);
			#endif
			restartButton.SetActive (true);
		}
	}


	// Gets called after user finishing entering name into NameInput field
	public void updateScoreBoard() {
		string name = GameObject.FindWithTag ("NameInput2").GetComponent<Text> ().text;
		Debug.Log ("New high score by " + name); 
		inp.SetActive (false); // Hide input field
		float[] highScores = new float[5];
		int curScore = GameManager.instance.curPoints;
		for (int i= 0; i < highScores.Length; i++){
			string curHighScoreKey = highScoreKey+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			int curHighScore = PlayerPrefs.GetInt(curHighScoreKey,0); 
			string namescore = PlayerPrefs.GetString(nameKey);
			if(curScore > curHighScore){
				int temp = curHighScore; // Score to push down
				string stemp = namescore;
				PlayerPrefs.SetInt (curHighScoreKey, curScore);
				PlayerPrefs.SetString (nameKey, name);
				curScore = temp;
				name = stemp;
			}
		}
		PlayerPrefs.Save ();
		printHighScores ();
		restartButton.SetActive (true);
	}

	public void resetScoreBoard() {
		float[] highScores = new float[5];
		foreach (GameManager.GameMode gameMode in Enum.GetValues(typeof(GameManager.GameMode))) {
			for (int i= 0; i < highScores.Length; i++){
				string highScoreKey = "HighScore" + gameMode.ToString() + (i+1).ToString();
				string nameKey = "Name" + (i + 1).ToString ();
				PlayerPrefs.SetInt (highScoreKey, 0);
				PlayerPrefs.SetString (nameKey, "Unknown");
			}
		}

	}

	public void printHighScores() {
		inp.SetActive (false);
		Text highScoresText = scoreBoard.GetComponent<Text> ();
		highScoresText.text = "High Scores: \n";
		scoreBoard.SetActive (true);
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){
			string curHighScoreKey = highScoreKey+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			int highScore = PlayerPrefs.GetInt(curHighScoreKey,0);
			string name = PlayerPrefs.GetString (nameKey, "none");
			highScoresText.text += ((i + 1).ToString() + ": " + name.ToString() + " " 
				+ highScore.ToString() + "\n");
		}
	}
}
