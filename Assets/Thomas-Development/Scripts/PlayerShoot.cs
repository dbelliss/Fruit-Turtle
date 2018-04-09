using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject pivot;
    private Vector3 direction;
    public GameObject cannonball;
    public GameObject cannonEnd;
    private Vector3 mousePosition;
	private AudioSource[] audio; 
	private AudioSource cannon;
    // Use this for initialization
    void Start () {
		audio = GetComponents<AudioSource> ();
		cannon = audio [0];
	}
	
	// Update is called once per frame
	void Update () {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Touch touch = Input.GetTouch(0);
            direction = (Vector3)touch.position - pivot.transform.position;
            direction.z = 0;
            if (touch.phase == TouchPhase.Began)
            {
                createCannonBall();
            }
        }
        else
        {
            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = mousePosition - pivot.transform.position;
            direction.z = 0;
            direction = direction.normalized;

            if (Input.GetButtonDown("Fire1"))
            {
                createCannonBall();
            }
        }
        pivot.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void createCannonBall()
    {
        cannon.Play();
        Instantiate(cannonball, cannonEnd.transform.position, Quaternion.identity);
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public Vector3 getTouchLocation()
    {
        return mousePosition;
    }
}
