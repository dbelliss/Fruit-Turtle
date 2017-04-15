using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody2D cannonballRB;
    public float speed;
    private PlayerShoot playerShootScript;
    private Vector3 cannonDirection;

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
}
