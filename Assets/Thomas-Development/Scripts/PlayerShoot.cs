using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject cannon;
    private Vector3 direction;
    public GameObject cannonball;
    public GameObject cannonEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cannon.activeInHierarchy) {
        Vector3 mousePosition;
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = mousePosition - cannon.transform.position;
        direction = direction.normalized;

			if (Input.GetButtonDown ("Fire1")) {
				Instantiate (cannonball, cannonEnd.transform.position, Quaternion.identity);
        
			}
		}
	}

    private void FixedUpdate()
	{
		if (cannon.activeInHierarchy) {
			cannon.transform.rotation = Quaternion.LookRotation (Vector3.forward, direction);
		}
	}
    public Vector3 GetDirection()
    {
        return direction;
    }
}
