using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody2D cannonballRB;
    public float speed;
    private PlayerShoot playerShootScript;
    private Vector3 cannonDirection;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        cannonballRB = GetComponent<Rigidbody2D>();
        playerShootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
        cannonDirection = playerShootScript.GetDirection();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        cannonballRB.velocity = cannonDirection * speed * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PointItem") {
			GameManager.losePoints (other.gameObject.GetComponent<Item> ().points);
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
		else if (other.tag == "BadItem") {
            Instantiate(explosion, other.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
