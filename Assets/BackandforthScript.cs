using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackandforthScript : MonoBehaviour {
    // Use this for initialization
    double timer;
    void Start () {
        timer = 0;
	}
    
	// Update is called once per frame
	void Update () {
        timer = timer + .01;
        //Debug.Log(Time.deltaTime);
        float z = (float)Math.Sin(timer);
        transform.Translate(0, 0, z);
	}
}