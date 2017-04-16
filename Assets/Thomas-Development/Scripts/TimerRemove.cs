using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRemove : MonoBehaviour {

    public float timeToRemove;
    private float currentTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime >= timeToRemove)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
	}
}
