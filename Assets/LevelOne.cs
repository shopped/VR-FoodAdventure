using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelOne : MonoBehaviour {

    bool nutrient;
    int count;
    public Transform Player;
    public GameObject molecule;
    private String[] mols = {"carbohydrate", "fat", "fiber", "protein", "watersm"};
    private String[] foods = {"Apple", "Cake", "Toast", "Walnut", "Broccoli" };

    void HideChildren(String name)
    {
        Renderer[] lChildRenderers = GameObject.Find(name).GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = false;
        }
    }
    void ShowChildren(String name)
    {
        Renderer[] lChildRenderers = GameObject.Find(name).GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = true;
        }
    }

    // Use this for initialization
    void Start () {
        nutrient = false;
        count = 0;
        molecule = null;
        GameObject.Find("watersm2").GetComponent<Renderer>().enabled = false;
        GameObject.Find("watersm3").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Saliva").GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find(mols[i]).GetComponent<Renderer>().enabled = false;
            HideChildren(foods[i]);
        }
        ShowChildren("Apple");
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("helloworld");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
        bool chewing = GameObject.Find("JawController").GetComponent<CheckY>().chewing;
        bool close = GameObject.Find("Hand").GetComponent<BackandforthScript>().close;
        // No nutrients. Food is close. Player is chewing. Not done with the level
        if (!nutrient && close && chewing && count != 5) {
                nutrient = true;
                HideChildren(foods[count]);
                GameObject.Find("Hand").GetComponent<BackandforthScript>().toggleMove();
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
                molecule.transform.Translate(new Vector3(0, 0, -.1f), Space.World);
                // If molecule is digested
                if (molecule.transform.position.z < -4)
                {
                    GameObject.Find(mols[count]).GetComponent<Renderer>().enabled = false;
                    if (count == 4)
                    {
                        GameObject.Find("watersm2").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("watersm3").GetComponent<Renderer>().enabled = false;
                    } else
                    {
                        GameObject.Find("Hand").GetComponent<BackandforthScript>().toggleMove();
                        count++;
                        ShowChildren(foods[count]);
                    }
                    nutrient = false;
                    molecule = null;
                }
            }
        } else
        {
            GameObject.Find("Saliva").GetComponent<Renderer>().enabled = false;
        }
        // Next Level Logic
        if (Player.position.z < -4 && count >= 4)
        {
            Debug.Log("Should start the next scene now!!!!!!!!!!!!!");
            StartCoroutine(LoadYourAsyncScene());
        }
    }
}
