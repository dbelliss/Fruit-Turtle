using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public float frequency;
	public float goodChance = .5f;
	public GameObject[] fruits;
	public GameObject[] obstacles;
	public Vector2 left;
	public Vector2 right;

	private BoxCollider2D bc2d;

	// Use this for initialization
	void Start () {
		bc2d = GetComponent<BoxCollider2D> ();
		left = this.gameObject.transform.position - new Vector3((bc2d.size.x / 2),0);
		right = this.gameObject.transform.position + new Vector3((bc2d.size.x / 2),0);
		StartCoroutine (spawn ());//Spawns things

	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		
	}

	IEnumerator spawn() {
		GameObject toSpawn;
		while (true) {
			if (Random.Range(0f, 1f) < goodChance) {
				toSpawn = fruits [Random.Range (0, fruits.Length)];
			}
			else {
				toSpawn = obstacles [Random.Range (0, obstacles.Length)];
			}

			float factor = Random.Range (0f, 1f);
			Vector2 pos = ((right - left) * factor) + left; //radomize x within range
			pos.y = this.gameObject.transform.position.y;//Same y level
			Instantiate(toSpawn, pos, Quaternion.identity); //Create
			yield return new WaitForSeconds(frequency);
		}
	}
}
