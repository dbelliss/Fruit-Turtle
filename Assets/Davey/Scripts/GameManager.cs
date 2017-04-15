using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	static public int pointsToWin = 10;
	static private int curPoints = 0;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		Debug.Log (curPoints);
	}


	static public void addPoints(int pts) {
		curPoints += pts;
		if (curPoints > pointsToWin) {
			Debug.Log ("YOU WIN");
		}
	}

	static public void losePoints(int pts) {
		curPoints -= pts;
		if (curPoints < 0) {
			Debug.Log ("You Lose");
		}
	}

    // Update is called once per frame

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
