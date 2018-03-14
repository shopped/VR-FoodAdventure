using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelOne : MonoBehaviour {

    bool nutrient;
    int count;
    public Transform Player;
    public GameObject molecule;
    private String[] mols = {"carbohydrate", "fat", "fiber", "protein", "watersm"};

    // Use this for initialization
    void Start () {
        nutrient = false;
        count = 0;
        molecule = null;
        GameObject.Find("carbohydrate").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fat").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fiber").GetComponent<Renderer>().enabled = false;
        GameObject.Find("protein").GetComponent<Renderer>().enabled = false;
        GameObject.Find("watersm").GetComponent<Renderer>().enabled = false;
        GameObject.Find("watersm2").GetComponent<Renderer>().enabled = false;
        GameObject.Find("watersm3").GetComponent<Renderer>().enabled = false;
        //GameObject.Find("Saliva").GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        bool chewing = GameObject.Find("JawController").GetComponent<CheckY>().chewing;
        bool close = GameObject.Find("Hand").GetComponent<BackandforthScript>().close;
        // No nutrients. Food is close. Player is chewing. Not done with the level
        if (!nutrient && close && chewing && count != 5) {
                nutrient = true;
                molecule = GameObject.Find(mols[count]);
                molecule.GetComponent<Renderer>().enabled = true;
                if (count == 4)
                {
                    GameObject.Find("watersm2").GetComponent<Renderer>().enabled = true;
                    GameObject.Find("watersm3").GetComponent<Renderer>().enabled = true;
                }
        }
        // Saliva Activation
        if (Math.Abs(Player.position.x) > 2)
        {
            GameObject.Find("Saliva").GetComponent<Renderer>().enabled = true;
            if (molecule != null)
            {
                Debug.Log(molecule.transform.position.x);
                molecule.transform.Translate(new Vector3(0, 0, -.1f), Space.World);
                if (molecule.transform.position.z < -4)
                {
                    GameObject.Find(mols[count]).GetComponent<Renderer>().enabled = false;
                    if (count == 4)
                    {
                        GameObject.Find("watersm2").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("watersm3").GetComponent<Renderer>().enabled = false;
                    }
                    nutrient = false;
                    molecule = null;
                    count++;
                }
            }
        } else
        {
            //GameObject.Find("Saliva").GetComponent<Renderer>().enabled = false;
        }
        // Next Level Logic
        if (Player.position.z < -4 && count == 4)
        {
            Debug.Log("Next Level!");
        }
    }
}
