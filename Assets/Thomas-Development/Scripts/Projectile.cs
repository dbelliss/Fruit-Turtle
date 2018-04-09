using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody2D cannonballRB;
    public float speed;
    private PlayerShoot playerShootScript;
    private Vector3 cannonDirection;
    public GameObject explosion;
    public float destroyTime;
    private WorldSpaceCanvas worldSpaceCanvas; // Attach new text to this world space canvas


    // Use this for initialization
    void Start () {
        cannonballRB = GetComponent<Rigidbody2D>();
        playerShootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
        cannonDirection = playerShootScript.GetDirection();
        cannonballRB.velocity = cannonDirection * speed * Time.deltaTime;
        worldSpaceCanvas = WorldSpaceCanvas.instance; // Attach new text to world space canvas
        Destroy(gameObject, destroyTime);
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PointItem") {
            GameManager.instance.losePoints(other.gameObject.GetComponent<Item>().points);
            Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
		else if (other.tag == "BadItem") {
            Instantiate(explosion, other.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            int pts = other.gameObject.GetComponent<Item>().points;
            worldSpaceCanvas.AddText(other.transform.position, "+" + pts.ToString());
            GameManager.instance.addPoints(pts);
            Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
