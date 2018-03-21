using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
	private AudioSource pickupSound;
    private WorldSpaceCanvas worldSpaceCanvas; // Attach new text to this world space canvas

    void Start() {
		pickupSound = GetComponent<AudioSource> ();
        worldSpaceCanvas  = WorldSpaceCanvas.instance; // Attach new text to world space canvas
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Contains ("Item")) {
			int pts = other.gameObject.GetComponent<Item> ().points;
			string tag = other.gameObject.tag;
			if (tag == "PointItem") {
                
                worldSpaceCanvas.AddText(other.transform.position, "+" + pts.ToString());
                pickupSound.Play ();
				GameManager.instance.addPoints (pts);
                Destroy(other.gameObject);
            }
            else if (tag == "BadItem") {
                worldSpaceCanvas.AddText(other.transform.position, "-" + pts.ToString());
                GameManager.instance.losePoints (pts);
				Destroy (other.gameObject);
			} else {
				Debug.Log ("UNKNOWN TAG: " + tag);
			}
		}
	}
}
