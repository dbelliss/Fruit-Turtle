using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItems : MonoBehaviour {

    public GameObject cannon;
    public GameObject basket;
    public GameObject pointLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
        {
            if (cannon.activeInHierarchy)
            {
                cannon.SetActive(false);
                basket.SetActive(true);
                pointLine.SetActive(true);
            }
            else
            {
                cannon.SetActive(true);
                basket.SetActive(false);
                pointLine.SetActive(false);
            }
        }
	}
}
