using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvas : MonoBehaviour {

    // Singletone instance
    public static WorldSpaceCanvas instance = null;

    [SerializeField]
    private GameObject scorePopup;

	void Awake () {
		if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Warning: Two WorldSpaceCanvas were created");
        }
	}

    // Returns text popup GameObject to appear when an item is collected
    private GameObject GetScorePopup()
    {
        if (scorePopup == null)
        {
            Debug.LogError("Error: Score popup was not set in WorldSpaceCanvas");
        }
        return scorePopup;
    }

    // Adds a text object at the world space position with the given text
    public void AddText(Vector2 position, string text)
    {
        GameObject go = GetScorePopup(); // Get popup object
        go = Instantiate(go, this.transform);

        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition = position;
        Text t = go.GetComponent<Text>();
        t.text = text;
    }
}
