using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {

	private EdgeCollider2D pointLine;
	private int currentPoint;
	public int pointToWin;

	// Use this for initialization
	void Start () {
		pointLine = GetComponent<EdgeCollider2D>();
	}

	// Update is called once per frame
	void Update () {
		if (currentPoint >= pointToWin)
		{
			//finish game
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("ENTERED");
		if (collision.gameObject.tag == "PointItem")
		{
			currentPoint++;
			Debug.Log(currentPoint);
		}
		if (collision.gameObject.tag == "BadItem")
		{
			currentPoint--;
			Debug.Log(currentPoint);
		}
	}
}
