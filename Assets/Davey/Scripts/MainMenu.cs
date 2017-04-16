using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InitScoreBoard ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

	void InitScoreBoard() {
		float[] highScores = new float[5];
		for (int i= 0; i < highScores.Length; i++){
			string highScoreKey = "HighScore"+(i+1).ToString();
			string nameKey = "Name" + (i + 1).ToString ();
			if (PlayerPrefs.GetFloat (highScoreKey) == 0) {
				PlayerPrefs.SetFloat (highScoreKey, 9999);
				PlayerPrefs.SetString (nameKey, "Unknown");
			}

		}
	}

	// Update is called once per frame
	void Update () {
		
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
