using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reload level

public class GameManager : MonoBehaviour {
	static public int pointsToWin = 10;
	static private int curPoints = 0;
	static private Text scoreText;

	// Use this for initialization


	void Start () {
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> ();
		if (scoreText == null) {
			Debug.Log ("Could not find score text");
		}
		printHighScores ();
	}
	void printHighScores() {
		int[] highScores = new int[5];
		for (int i= 0; i < highScores.Length; i++){

			//Get the highScore from 1 - 5
			string highScoreKey = "HighScore"+(i+1).ToString();
			int highScore = PlayerPrefs.GetInt(highScoreKey,0);
			Debug.Log (i.ToString() + " " + highScore.ToString());

		}
	}

	void Update() {
		Debug.Log (curPoints); 
		if (Input.GetAxis("Reset") != 0) {
			updateScoreBoard ();
			curPoints = 0;
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	static void updatePoints(){
		scoreText.text = "Score : " + curPoints.ToString ();
	}


	static public void addPoints(int pts) {
		curPoints += pts;
		updatePoints ();
		if (curPoints > pointsToWin) {
			updateScoreBoard ();
			Debug.Log ("YOU WIN");
		}
	}

	static void updateScoreBoard() {
		int[] highScores = new int[5];
		int score = (int)Time.timeSinceLevelLoad;
		for (int i= 0; i < highScores.Length; i++){
			
			//Get the highScore from 1 - 5
			string highScoreKey = "HighScore"+(i+1).ToString();
			int highScore = PlayerPrefs.GetInt(highScoreKey,0);
			//if score is greater, store previous highScore
			//Set new highScore
			//set score to previous highScore, and try again
			//Once score is greater, it will always be for the
			//remaining list, so the top 5 will always be 
			//updated
			if(score>highScore){
				int temp = highScore;
				PlayerPrefs.SetInt (highScoreKey, score);
				score = temp;
			}
		}
	}

	static public void losePoints(int pts) {
		curPoints -= pts;
		updatePoints ();
		if (curPoints < 0) {
			Debug.Log ("You Lose");
		}
	}

    // Update is called once per frame

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.tag.Contains ("Player")) {
			return;
		}
		else
        	Destroy(collision.gameObject);
    }
}
