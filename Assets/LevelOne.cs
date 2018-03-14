using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour {

    bool nutrient;
    int count;

	// Use this for initialization
	void Start () {
        nutrient = false;
        count = 0;
        GameObject.Find("carbohydrate").GetComponent<Renderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        bool chewing = GameObject.Find("JawController").GetComponent<CheckY>().chewing;
        bool close = GameObject.Find("Hand").GetComponent<BackandforthScript>().close;
        if (!nutrient && close && chewing) {
                nutrient = true;
                GameObject.Find("carbohydrate").GetComponent<Renderer>().enabled = true;
                count++;
        }
    }
}
