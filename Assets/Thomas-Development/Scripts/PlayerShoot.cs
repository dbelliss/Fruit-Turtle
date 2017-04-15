using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject cannon;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition;
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = mousePosition - cannon.transform.position;
	}

    private void FixedUpdate()
    {
        cannon.transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);
    }
}
