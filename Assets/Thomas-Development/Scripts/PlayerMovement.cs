using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerRB;
    public float speed = 100.0f;
	bool isMovingRight = true;
	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();

		#if UNITY_IOS || UNITY_ANDROID
		Input.multiTouchEnabled = true; //enabled Multitouch
		#endif
	}

	void Flip() {
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y);
		isMovingRight = !isMovingRight;
	}

    private void FixedUpdate()
    {
		
        Vector3 movement;
		int hMovement = 0;
		#if UNITY_IOS || UNITY_ANDROID
		// Move right if touching the right half of the screen, and left if the other halfs
		foreach (Touch t in Input.touches)
		{
		if (t.position.x > Screen.width/2) {
		hMovement = 1;
		break;
		}
		else if (t.position.x < Screen.width/2) {
		hMovement = -1;
		break;
		}
		}
		#else
		hMovement = (int)Input.GetAxisRaw ("Horizontal");
		#endif
		movement = new Vector3(hMovement, 0.0f, 0.0f);
        playerRB.velocity = movement * speed;

		// Adjust sprite rotation
		if (hMovement > 0) {
			if (isMovingRight == false) {
				Flip ();
			}
		}
		else if (hMovement < 0){
			if (isMovingRight == true){
				Flip();
			}
		}
    }
}
