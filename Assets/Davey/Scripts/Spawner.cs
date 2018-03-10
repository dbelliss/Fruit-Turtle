using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField]
	private float frequency; // How often to spawn a new item
	[SerializeField]
	private float goodChance; // Chance of a fruit

	public GameObject[] fruits;
	public GameObject[] obstacles;

	public Vector2 leftBoundary;
	public Vector2 rightBoundary;

	private BoxCollider2D bc2d;

	// Use this for initialization
	void Start () {
		bc2d = GetComponent<BoxCollider2D> ();
		leftBoundary = this.gameObject.transform.position - new Vector3((bc2d.size.x / 2),0);
		rightBoundary = this.gameObject.transform.position + new Vector3((bc2d.size.x / 2),0);
		StartCoroutine (spawn ());//Spawns things
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
			Vector2 pos = ((rightBoundary - leftBoundary) * factor) + leftBoundary; //radomize x within range
			pos.y = this.gameObject.transform.position.y;//Same y level
			Instantiate(toSpawn, pos, Quaternion.identity); //Create
			yield return new WaitForSeconds(frequency);
		}
	}
}
