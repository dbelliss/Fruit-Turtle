using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
    // Use this for initialization
    void Start () {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
