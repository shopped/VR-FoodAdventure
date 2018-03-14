using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelThree : MonoBehaviour {
    private int score;
    public int time;
    private int tenth;
    private int nextTimer;
    private string[] nutrient_list = { "Calcium", "Vit K", "Folic Acid", "Nitrates", "Magnesium", "Vit B", "Omega 3 Acid", "Vit A", "Vit D", "Vit C", "Trans Fats", "Vit F", "Vit E", "Potassium" };
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
        nutrient_dict.Add("Omega 3 Acid", "Fat");
        nutrient_dict.Add("Vit A", "Fat");
        nutrient_dict.Add("Vit D", "Fat");
        nutrient_dict.Add("Vit C", "Water");
        nutrient_dict.Add("Trans Fats", "Poison");
        nutrient_dict.Add("Vit F", "Poison");
        nutrient_dict.Add("Vit E", "Fat");
        nutrient_dict.Add("Potassium", "Mineral");
    }

    public void addScore()
    {
        score++;
    }

    public void loseScore()
    {
        score = score - 10;
    }
	
	// Update is called once per frame
	void Update () {
        tenth++;
        if (tenth >= 10)
        {
            tenth = 0;
            time--;
            nextTimer--;
            if (nextTimer == 0)
            {
                nextTimer = 10;
                generateNext();
            }
        }
        if (time == 0)
        {
            StartCoroutine(LoadYourAsyncScene());
        }
	}
    private void generateNext()
    {
        if (index < 14)
        {
            Debug.Log(nutrient_list[index]);
            var theText = new GameObject();
            var textMesh = theText.AddComponent<TextMesh>() as TextMesh;
            var meshRenderer = theText.AddComponent<MeshRenderer>() as MeshRenderer;

            textMesh.text = nutrient_list[index];

            index++;
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("level-4");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
