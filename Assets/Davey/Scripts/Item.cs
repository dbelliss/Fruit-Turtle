using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public int points = 1;
	public float grav = 1;
	private float angularSpeed;
	private Rigidbody2D rb2d;
	private Transform trans;
	// Use this for initialization
	void Start () {
		angularSpeed = Random.Range (4f, 10f);
		trans = GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.gravityScale = grav;
	}
	
	// Update is called once per frame
	void Update () {
		rotate ();
	}

	void rotate() {
		trans.Rotate(Vector3.forward * angularSpeed);
	}
}
