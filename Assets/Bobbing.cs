using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bobbing : MonoBehaviour
{
    // Use this for initialization
    double timer;
    public bool moving;
    void Start()
    {
        moving = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + .01;
        //Debug.Log(Time.deltaTime);
        float delta = (float)(.008 * (float)Math.Sin(timer));
        transform.Translate(0, delta, 0);
        if (moving == true)
        {
            transform.Translate(0, 0, .1f);
        }
    }
}