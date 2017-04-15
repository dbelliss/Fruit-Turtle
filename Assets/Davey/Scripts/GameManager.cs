using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	}

	void Update() {
		Debug.Log (curPoints);
	}

	static void updatePoints(){
		scoreText.text = "Score : " + curPoints.ToString ();
	}


	static public void addPoints(int pts) {
		curPoints += pts;
		updatePoints ();
		if (curPoints > pointsToWin) {
			Debug.Log ("YOU WIN");
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
