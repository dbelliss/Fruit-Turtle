using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerRB;
    private PlayerShoot playerShootScript;
    public float speed = 100.0f;
	bool isMovingRight = true;
	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        playerShootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();

        if (SystemInfo.deviceType == DeviceType.Handheld)
            Input.multiTouchEnabled = true; //enabled Multitouch
    }

	void Flip() {
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y);
		isMovingRight = !isMovingRight;
	}

    private void FixedUpdate()
    {
		
        Vector3 movement;
		int hMovement = 0;
        if (SystemInfo.deviceType == DeviceType.Handheld && GameManager.instance.curGameMode == GameManager.GameMode.CATCHER)
        {
            // Move right if touching the right half of the screen, and left if the other halfs
            foreach (Touch t in Input.touches)
            {
                if (t.position.x > Screen.width / 2)
                {
                    hMovement = 1;
                    break;
                }
                else if (t.position.x < Screen.width / 2)
                {
                    hMovement = -1;
                    break;
                }
            }
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld && GameManager.instance.curGameMode == GameManager.GameMode.DEFENDER)
        {
            if (playerShootScript.GetDirection().x > 0.1)
            {
                hMovement = 1;
            }
            else if (playerShootScript.GetDirection().x < -0.1)
            {
                hMovement = -1;
            }
            else
            {
                hMovement = 0;
            }
        }
        else
        {
            hMovement = (int)Input.GetAxisRaw("Horizontal");
        }
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
