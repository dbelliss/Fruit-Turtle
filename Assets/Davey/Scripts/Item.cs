using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public int points = 1;
	private float angularSpeed;
	private Transform trans;
	// Use this for initialization
	void Start () {
		angularSpeed = Random.Range (4f, 10f);
		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rotate ();
	}

	void rotate() {
		trans.Rotate(Vector3.forward * angularSpeed);
	}
}
