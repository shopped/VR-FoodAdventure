using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : MonoBehaviour {

    private bool unblocked;
    private bool istalking;
    private bool iswhispering;
    private int talktime;

	// Use this for initialization
	void Start () {
        unblocked = false;
        talktime = 0;
	}

    public void unblock()
    {
        unblocked = true;
    }

    public void proceed()
    {
        if (unblocked == true)
        {
            StartCoroutine(LoadYourAsyncScene())
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("level3-small");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
		if (talktime > 0)
        {
            talktime--;
            if (talktime == 0)
            {
                GameObject.Find("talking").GetComponent<Renderer>().enabled = false;
                GameObject.Find("whispering").GetComponent<Renderer>().enabled = false;
            }
        }
	}

    void talk(int time, bool whispering)
    {
        if (whispering)
        {
            GameObject.Find("talking").GetComponent<Renderer>().enabled = true;
            GameObject.Find("whispering").GetComponent<Renderer>().enabled = false;
        } else
        {
            GameObject.Find("whispering").GetComponent<Renderer>().enabled = true;
            GameObject.Find("talking").GetComponent<Renderer>().enabled = false;
        }
        talktime = time;
    }


}
