using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player"){
			return;
		}
		else {
			if (other.gameObject.tag == "BadItem") {
				GameManager.losePoints (other.gameObject.GetComponent<Item> ().points);
			}
			GetComponent<AudioSource> ().Play ();
			Destroy (other.gameObject);
		}
	}
}
