using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerRB;
    public float speed = 100.0f;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float horizontalMovement;
        Vector3 movement;

        horizontalMovement = Input.GetAxis("Horizontal");

        movement = new Vector3(horizontalMovement, 0.0f, 0.0f);

        playerRB.velocity = movement * speed * Time.deltaTime;
    }
}
