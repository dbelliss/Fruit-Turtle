using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText : MonoBehaviour {
    private int displayTime = 2;
    private float numIntervals = 20f; // Number of steps when rising and fading
    private float netHeightChange = .5f; // How far the object should rise before fading completely\

	void Start () {
        StartCoroutine(FadeAway());
	}
	
    // Score text slowly rises and loses opacity
    IEnumerator FadeAway()
    {
        float interval = displayTime / numIntervals;
        float changeInHeight = netHeightChange / numIntervals;
        float changeInAlpha = 1 / numIntervals;
        Text t = GetComponent<Text>();
        for (int i = 0; i < numIntervals; i++)
        {
            this.transform.position = this.transform.position + new Vector3(0, changeInHeight); // Slowly rise
            t.color = t.color - new Color(0, 0, 0, changeInAlpha); // Slowly fade away, be transparent by the end of Coroutine
            yield return new WaitForSeconds(interval);
        }
        Destroy(this.gameObject);
        yield return null;
    }
}
