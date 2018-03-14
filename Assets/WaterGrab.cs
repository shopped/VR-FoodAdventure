using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGrab : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hello");
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hi!");
        //GameObject.Find("Level 3").GetComponent<LevelThree>().touch(col.gameObject.name, true);
        Destroy(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
