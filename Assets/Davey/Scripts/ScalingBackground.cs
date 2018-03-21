using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingBackground : MonoBehaviour {

	// Scales background to camera size at start
	void Awake () {
        Screen.orientation = ScreenOrientation.LandscapeLeft; // Lock screen to landscape
        StartCoroutine(SetBackgroundSize());
	}

    IEnumerator SetBackgroundSize()
    {
        while (true)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            float worldScreenHeight = Camera.main.orthographicSize * 2;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            transform.localScale = new Vector3(
                worldScreenWidth / sr.sprite.bounds.size.x,
                worldScreenHeight / sr.sprite.bounds.size.y, 1);
            yield return new WaitForSeconds(.5f);
        }

        
    }
}
