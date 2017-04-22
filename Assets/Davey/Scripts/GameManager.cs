﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reload level

public class GameManager : MonoBehaviour {
	static bool isActive = true;
	static public int pointsToWin = 10;
	static private int curPoints = 0;
	static private Text scoreText;
	public GameObject sb;
	private ScoreManager sm;

	void Start () {
		isActive = true;
		sm = sb.GetComponent<ScoreManager> ();
//		sm.resetScoreBoard ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> ();
		if (scoreText == null) {
			Debug.Log ("Could not find score text");
		}
	}

	void Awake() {
		isActive = true;
	}
		
	void Update() {
		if (Input.GetAxis("Reset") != 0) {
			curPoints = 0;
			SceneManager.LoadScene (0);
		}
		scoreText.text = "Time: " + Time.timeSinceLevelLoad.ToString ();
	}

	static void updatePoints(){
		scoreText.text = "Score : " + curPoints.ToString ();
	}


	static public void addPoints(int pts) {
		if (isActive == true) {
			curPoints += pts;

			if (curPoints > pointsToWin && isActive == true) {
				GameObject.FindWithTag ("ScoreManager").gameObject.GetComponent<ScoreManager> ().endGame ();
				Debug.Log ("YOU WIN");
				isActive = false;
			}
		}

	}



	static public void losePoints(int pts) {
		if (isActive == true) {
			curPoints -= pts;
			if (curPoints < 0) {
				curPoints = 0;
			}
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

    public static int GetCurrentPoints()
    {
        return curPoints;
    }
}
