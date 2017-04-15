using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerRB;
    public float speed = 100.0f;
	private Transform trans;
	bool isMovingRight = true;
	// Use this for initialization
	void Start () {
		
        playerRB = GetComponent<Rigidbody2D>();
		trans = GetComponent<Transform> ();
	}

	void flip() {
		trans.localScale = new Vector3 (trans.localScale.x * -1, trans.localScale.y);
		isMovingRight = !isMovingRight;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") > 0) {
			if (isMovingRight == false) {
				flip ();
			}
		}
		else if (Input.GetAxis("Horizontal") < 0){
			if (isMovingRight == true){
				flip();
			}
		}
		else {
			//do not change
		}
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
