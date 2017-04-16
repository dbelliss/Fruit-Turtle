using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reload level

public class GameManager : MonoBehaviour {
	static public int pointsToWin = 10;
	static private int curPoints = 0;
	static private Text scoreText;
	public GameObject sb;
	private ScoreManager sm;
	public GameObject inp;
	// Use this for initialization


	void Start () {
		
		sm = sb.GetComponent<ScoreManager> ();
//		sm.resetScoreBoard ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> ();
		if (scoreText == null) {
			Debug.Log ("Could not find score text");
		}
//		sm.printHighScores ();
	}
		
	void Update() {
		Debug.Log ("TIME " + Time.timeSinceLevelLoad);
		Debug.Log (curPoints); 
		if (Input.GetAxis("Reset") != 0) {
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
			GameObject.FindWithTag("ScoreManager").gameObject.GetComponent<ScoreManager>().endGame();
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
