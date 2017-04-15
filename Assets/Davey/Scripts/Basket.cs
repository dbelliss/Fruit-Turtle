using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		int pts = other.gameObject.GetComponent<Item> ().points;
		string tag = other.gameObject.tag;
		Debug.Log("ENTERED");
		if (tag == "PointItem")
		{
			GameManager.addPoints (pts);
			Destroy (other.gameObject);
		}
		else if (tag == "BadItem")
		{
			GameManager.losePoints (pts);
			Destroy (other.gameObject);
		}
		else {
			Debug.Log ("UNKNOWN TAG: " + tag);
		}
	}
}
