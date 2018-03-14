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
        delta = 0;
        chewing = false;
	}
	
	// Update is called once per frame
	void Update () {
        delta = (transform.position.y - lastY);
        lastY = this.transform.position.y;
        if (delta * 10 > 1 || delta * 10 < -1)
        {
            chewing = true;
        }
        else
        {
            chewing = false;
        }
    }
}
