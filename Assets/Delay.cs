using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour {
    int timer;
	// Use this for initialization
	void Start () {
        timer = 3000;
	}
	
	// Update is called once per frame
	void Update () {
        timer--;
		if (timer == 0)
        {
                GameObject.Find("Voice 024").GetComponent<AudioSource>().Play();
        }
	}
}
