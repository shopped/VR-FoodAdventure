using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;

public class LevelThree : MonoBehaviour {
    private int score;
    public int time;
    private int tenth;
    private int nextTimer;
    private string[] nutrient_list = { "Calcium", "Vit K", "Folic Acid", "Nitrates", "Magnesium", "Vit B", "Omega 3 Acid", "Vit A", "Vit D", "Vit C", "Trans Fats", "Vit F", "Vit E", "Potassium" };
    private List<GameObject> current_nutrients = new List<GameObject>();
    private String[] picked_nutrients = new String[14];
    private Dictionary<string, string> nutrient_dict = new Dictionary<string, string>();
    private int index = 0;

    // Use this for initialization
    void Start () {
        score = 0;
        time = 150;
        tenth = 0;
        index = 0;
        nextTimer = 10;
        nutrient_dict.Add("Calcium", "Mineral");
        nutrient_dict.Add("Vit K", "Fat");
        nutrient_dict.Add("Folic Acid", "Water");
        nutrient_dict.Add("Nitrates", "Poison");
        nutrient_dict.Add("Magnesium", "Mineral");
        nutrient_dict.Add("Vit B", "Water");
        nutrient_dict.Add("Omega 3 Acid", "Mineral");
        nutrient_dict.Add("Vit A", "Fat");
        nutrient_dict.Add("VitD", "Fat");
        nutrient_dict.Add("Vit C", "Water");
        nutrient_dict.Add("Trans Fats", "Poison");
        nutrient_dict.Add("Vit F", "Poison");
        nutrient_dict.Add("Vit E", "Fat");
        nutrient_dict.Add("Potassium", "Mineral");
    }

    public void touch(string name, bool water)
    {
        Debug.Log("Touch!");
        bool picked = false;
        for (int i = 0; i < 14; i++)
        {
            if (picked_nutrients[i] == name)
            {
                picked = true;
            }
        }
        if (picked == false)
        {
            current_nutrients.Remove(GameObject.Find(name));
            Debug.Log(nutrient_dict[name]);
        }
    }

    private void addScore()
    {
        score++;
    }

    private void loseScore()
    {
        score = score - 10;
    }
	
	// Update is called once per frame
	void Update () {
        tenth++;
        if (tenth >= 60)
        {
            tenth = 0;
            time--;
            nextTimer--;
            GameObject.Find("Timer").GetComponent<TextMesh>().text = time + Regex.Unescape("\n left");
            if (nextTimer == 0)
            {
                nextTimer = 20;
                generateNext();
            }
        }
        if (time == 0)
        {
            StartCoroutine(LoadYourAsyncScene());
        }
        foreach (var val in current_nutrients)
        {
            val.transform.Translate(0, 0, -.01f);
            if (val.transform.position.z < -10)
            {
                val.GetComponent<Renderer>().enabled = false;
                current_nutrients.Remove(val);
            }
        }
	}
    System.Random rnd = new System.Random();
    private void generateNext()
    {
        if (index < 14)
        {
            var theText = new GameObject();
            int x = rnd.Next(-2, 2);
            int y = rnd.Next(0, 2);
            theText.transform.Translate(x, .5f + y, 10);
            var textMesh = theText.AddComponent<TextMesh>() as TextMesh;
            textMesh.text = nutrient_list[index];
            current_nutrients.Add(theText);
            index++;
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("level4-large");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
