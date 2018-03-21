using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reload level

public class GameManager : MonoBehaviour {

	// Singleton GameManager reference
	public static GameManager instance {
		get;
		private set;
	}

	bool isActive = true;

	public float timeLeft {
		get;
		private set;
	}

	private int curTime = 0;

	public int curPoints {
		get;
		private set;
	}

	public enum GameMode {
		DEFENDER,
		CATCHER,
		COOPCATCHER
	}

	[SerializeField]
	private GameMode _curGameMode;

	public GameMode curGameMode {
		get {
			return _curGameMode;
		}
	} // Public faving variable for gameMode

	[SerializeField]
	private Text timeText; 

	[SerializeField]
	private Text scoreText;

	static private ScoreManager sm;

	void Awake () {
		if (instance != null) {
			Debug.LogError ("Error: two GameManagers were created");
			return;
		} 
		if (timeText == null) {
			Debug.LogError ("Could not find time text");
		}
		if (scoreText == null) {
			Debug.LogError ("Could not find score text");
		}
		instance = this;

	}

	void Start() {
		Debug.Log ("Gamemode is " + _curGameMode);
		curPoints = 0;
		timeLeft = 30f; // Initialize to 30 second round
		timeText.text = timeLeft.ToString("00");
		StartCoroutine (CountDown ());
		sm = ScoreManager.instance; // Get score manager instance
	}

	IEnumerator CountDown() {
		while (timeLeft >= 5) {
			timeLeft -= 1;
			timeText.text = timeLeft.ToString("00");
			yield return new WaitForSeconds (1f);
		}
		while (timeLeft > 0.01) {
			timeLeft -= .1f;
			timeText.text = timeLeft.ToString("0.0");
			yield return new WaitForSeconds (.1f);
		}
		EndGame ();
	}
		
	void Update() {
		if (Input.GetAxis("Reset") != 0 && Input.GetKey(KeyCode.Escape)) {
			// Back to main menu
			BackToMainMenu();
		} 
	}

	public void BackToMainMenu() {
		timeText.text = "";
		curPoints = 0;
		SceneManager.LoadScene (0);
	}

	void UpdatePoints(){
		scoreText.text = "Score : " + curPoints.ToString ();
	}


	public void addPoints(int pts) {
        if (timeLeft <= 0)
        {
            return;
        }
		curPoints += pts;
		UpdatePoints ();
	}

	private void EndGame() {
		timeLeft = 0;
		timeText.text = "0.0";
		sm.EndGame ();
	}
		
	public void losePoints(int pts) {
        if (timeLeft <= 0)
        {
            return;
        }
        curPoints -= pts;
		if (curPoints < 0) {
			curPoints = 0;
		}
		UpdatePoints ();
	}
		
    public int GetCurrentPoints()
    {
        return curPoints;
    }
}
