using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelOne : MonoBehaviour {

    bool nutrient;
    int count;
    public Transform Player;

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
        Debug.Log(Player.position.x);
        Debug.Log(Player.position.y);
        Debug.Log(Player.position.z);
        if (Math.Abs(Player.position.x) > 2)
        {
            Debug.Log("Saliva!");
        }
        if (Player.position.z < -4)
        {
            Debug.Log("Next Level!");
        }
    }
}
