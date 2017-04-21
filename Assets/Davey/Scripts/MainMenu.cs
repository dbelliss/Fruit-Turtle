using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public Slider difficultySlider;
	float prevDifficulty;
    // Use this for initialization
    void Start () {
		prevDifficulty = .25f;
//		InitScoreBoard ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

	void InitScoreBoard() {
		Debug.Log ("Initialize board");
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			PlayerPrefs.SetFloat (highScoreKey, 999f);
			PlayerPrefs.SetString (nameKey, "Unknown");
		}
		PlayerPrefs.Save ();
	}

	void Awake() {
//		resetScoreBoard ();
	}

	// Update is called once per frame
	void Update () {
		if (difficultySlider.value != prevDifficulty) {
			InitScoreBoard ();
			prevDifficulty = difficultySlider.value;
		}
        string difficultyKey = "difficulty";
        PlayerPrefs.SetFloat(difficultyKey, 1.0f - difficultySlider.value);
    }

	public void resetScoreBoard() {
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			PlayerPrefs.SetFloat (highScoreKey, 9999f);
			PlayerPrefs.SetString (nameKey, "Unknown");
		}
		PlayerPrefs.Save ();
	}

	public void quit() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void load() {
		SceneManager.LoadScene (1);
	}
}
