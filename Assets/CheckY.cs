using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckY : MonoBehaviour {
    double lastY;
    double delta;
    public bool chewing;
	// Use this for initialization
	void Start () {
        lastY = 2.5;
        chewing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (delta < 5)
        {
            delta += Math.Abs(transform.position.y - lastY);
        }
        if (delta > 3)
        {
            chewing = true;
        } else
        {
            chewing = false;
        }
        lastY = transform.position.y;
        if (delta > 0)
        {
            delta -= .1;
        }
    }
}
