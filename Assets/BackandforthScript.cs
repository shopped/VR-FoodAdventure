using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackandforthScript : MonoBehaviour {
    // Use this for initialization
    double timer;
    public bool close;
    public bool moving;
    void Start () {
        timer = 0;
        moving = true;
        close = false;
        transform.Translate(0, 3, -5);
	}

    public void toggleMove()
    {
        moving = !moving;
    }
    
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timer = timer + .01;
            float z = (float)(Math.Sin(timer));
            transform.Translate(0, 0, z);
            if (transform.position.z < 40)
            {
                close = true;
            } else {
                close = false;
            }
            if (transform.position.z > 150)
            {
                transform.Translate(0, -z*1f, 0);
            }
            
        }
	}
}