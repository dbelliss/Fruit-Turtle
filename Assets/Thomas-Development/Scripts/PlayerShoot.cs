using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject pivot;
    private Vector3 direction;
    public GameObject cannonball;
    public GameObject cannonEnd;
    public float pullRadius;
    public float pullForce;
    private Vector3 mousePosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = mousePosition - pivot.transform.position;
        direction = direction.normalized;

		if (Input.GetButtonDown ("Fire1") && cannonEnd.activeInHierarchy) {
			Instantiate (cannonball, cannonEnd.transform.position, Quaternion.identity);
	    }
	}

    private void FixedUpdate()
	{
		if (pivot.activeInHierarchy) {
			pivot.transform.rotation = Quaternion.LookRotation (Vector3.forward, direction);
		}

        // FORCE PULL
        if (Input.GetButton("Fire1") && !cannonEnd.activeInHierarchy)
        {
            Collider2D[] colliderArray;

            colliderArray = Physics2D.OverlapCircleAll(mousePosition, pullRadius);
            for (int i = 0; i < colliderArray.Length; i++)
            {
                if (colliderArray[i].tag == "PointItem" || colliderArray[i].tag == "BadItem")
                {
                    Vector3 forceDirection = colliderArray[i].transform.position - mousePosition;
                    forceDirection = forceDirection.normalized;
                    colliderArray[i].GetComponent<Rigidbody2D>().velocity = forceDirection * -pullForce;
                }
            }
        }
	}
    public Vector3 GetDirection()
    {
        return direction;
    }
}
