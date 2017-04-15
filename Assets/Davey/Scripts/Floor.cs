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
		Debug.Log ("Col");
		if (other.gameObject.tag == "Player"){
			
		}
		else {
			Destroy (other.gameObject);
		}
	}
}
