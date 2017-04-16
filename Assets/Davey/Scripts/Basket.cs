using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {
	private AudioSource audio;
	void Start() {
		audio = GetComponent<AudioSource> ();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Contains ("Item")) {
			int pts = other.gameObject.GetComponent<Item> ().points;

			string tag = other.gameObject.tag;
			if (tag == "PointItem") {
				audio.Play ();
				GameManager.addPoints (pts);
				Destroy (other.gameObject);
			} else if (tag == "BadItem") {
				GameManager.losePoints (pts);
				Destroy (other.gameObject);
			} else {
				Debug.Log ("UNKNOWN TAG: " + tag);
			}
		}
	}
}
