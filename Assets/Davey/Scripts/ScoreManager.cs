using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; // Enum

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    bool isMainMenu = false; // Set to true when on main menu to prevent unecessary checks

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

		if (!isMainMenu && (scoreBoard == null || inp == null || highScoreText == null
            || inputFieldText == null)) {
			Debug.LogError("Error: Score manager has an unset variable");
		}
		instance = this;
	}

	void Start() {
        if (!isMainMenu)
        {
            highScoreKey = "HighScore" + GameManager.instance.curGameMode.ToString();
            currentHigh = PlayerPrefs.GetInt(highScoreKey + "1", 0); // Get first on highscore list for this gamemode
            currentLow = PlayerPrefs.GetInt(highScoreKey + "5", 0);
            if (highScoreText != null)
            {
                highScoreText.GetComponent<Text>().text = "High Score: " + currentHigh.ToString();
            }
        }
        else
        {
            // TODO 
            highScoreKey = "HighScore" + GameManager.GameMode.CATCHER.ToString();
        }
	}

	public void EndGame() {
		int finalScore = GameManager.instance.curPoints;
		PrintCurGameModeHighScores ();
		if (currentLow < finalScore) { 
			// Allow input of new high score name
			inp.SetActive (true);   
		} 
		else
		{
			// Show restart information
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
            string nameKey = "Name" + GameManager.instance.curGameMode.ToString() + (i + 1).ToString ();
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
        PrintCurGameModeHighScores ();
		restartButton.SetActive (true);
	}

	public void resetScoreBoard() {
		float[] highScores = new float[5];
		foreach (GameManager.GameMode gameMode in Enum.GetValues(typeof(GameManager.GameMode))) {
			for (int i = 0; i < highScores.Length; i++){
				string highScoreKey = "HighScore" + gameMode.ToString() + (i+1).ToString();
                string nameKey = "Name" + gameMode.ToString() + (i + 1).ToString ();
				PlayerPrefs.SetInt (highScoreKey, 0);
				PlayerPrefs.SetString (nameKey, "Unknown");
			}
		}
	}

    public void PrintCurGameModeHighScores() {
        if (!isMainMenu)
        {
            inp.SetActive(false);
        }
        highScoreKey = "HighScore" + GameManager.instance.curGameMode.ToString();
        Text highScoresText = scoreBoard.GetComponent<Text> ();
        highScoresText.text = "High Scores:\n";
        scoreBoard.SetActive (true);
        float[] highScores = new float[5];
        for (int i= 0; i < highScores.Length; i++){
            string curHighScoreKey = highScoreKey+(i+1).ToString();
            string nameKey = "Name" + GameManager.instance.curGameMode.ToString() + (i + 1).ToString ();
            int highScore = PlayerPrefs.GetInt(curHighScoreKey,0);
            string name = PlayerPrefs.GetString (nameKey, "none");
            highScoresText.text += ((i + 1).ToString() + ": " + name.ToString() + " " 
                + highScore.ToString() + "\n");
        }
    }

    public void PrintHighScores(GameManager.GameMode gameMode) {
        if (!isMainMenu)
        {
            inp.SetActive(false);
        }
        highScoreKey = "HighScore" + gameMode.ToString();
        Text highScoresText = scoreBoard.GetComponent<Text> ();
        highScoresText.text = "High Scores:\n";
        scoreBoard.SetActive (true);
        float[] highScores = new float[5];
        for (int i= 0; i < highScores.Length; i++){
            string curHighScoreKey = highScoreKey+(i+1).ToString();
            string nameKey = "Name" + gameMode.ToString() + (i + 1).ToString ();
            int highScore = PlayerPrefs.GetInt(curHighScoreKey,0);
            string name = PlayerPrefs.GetString (nameKey, "none");
            highScoresText.text += ((i + 1).ToString() + ": " + name.ToString() + " " 
                + highScore.ToString() + "\n");
        }
    }

    // Print highscores for the given game mode
    public void PrintHighScores(int gameModeNum) {
        PrintHighScores ((GameManager.GameMode)gameModeNum); // Print cur gamemode
    }
}
