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
	}
    
	// Update is called once per frame
	void Update () {
        timer = timer + .01;
        float z = (float)(Math.Sin(timer));
        if (z < -.8)
        {
            close = true;
        } else
        {
            close = false;
        }
        transform.Translate(0, 0.001f, z);
	}
}