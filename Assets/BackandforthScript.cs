using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackandforthScript : MonoBehaviour {
    // Use this for initialization
    double timer;
    public bool close;
    void Start () {
        timer = 0;
        close = false;
        transform.Translate(0, 3, -5);
	}
    
	// Update is called once per frame
	void Update () {
        timer = timer + .01;
        float z = (float)(Math.Sin(timer));
        transform.Translate(0, 0, z);
        if (transform.position.z < 40)
        {
            close = true;
        }
        else
        {
            close = false;
        }
        // Debug.Log(close);
	}
}