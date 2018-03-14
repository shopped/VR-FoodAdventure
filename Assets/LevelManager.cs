using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace HoloToolkit.Unity.InputModule
{
    public class LevelManager : MonoBehaviour, IInputClickHandler
    {
        private bool unblocked;
        private bool istalking;
        private bool iswhispering;
        private int talktime;
        private int level = 0;
        // Use this for initialization
        void Start()
        {
            unblocked = false;
            talktime = 0;
            // sinktimer = 0;
            level = 0;
            talk(300, true, false);
        }

        // Update is called once per frame
        void Update()
        {
            if (talktime > 0)
            {
                talktime--;
                if (talktime == 0)
                {
                    talk(0, false, false);
                }
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            level++;
            if (level == 4)
                level = 0;

            switch(level)
            {
                case 0:
                    SceneManager.LoadScene("level0", LoadSceneMode.Single);
                    break;
                case 1:
                    SceneManager.LoadScene("level1", LoadSceneMode.Single);
                    break;
                case 2:
                    SceneManager.LoadScene("level2", LoadSceneMode.Single);
                    break;
                case 3:
                    SceneManager.LoadScene("level3", LoadSceneMode.Single);
                    break;
                case 4:
                    SceneManager.LoadScene("level4", LoadSceneMode.Single);
                    break;

            }

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        void talk(int time, bool talking, bool whispering)
        {
            if (talking && whispering)
            {
                GameObject.Find("talking").GetComponent<Renderer>().enabled = false;
                GameObject.Find("whispering").GetComponent<Renderer>().enabled = true;
                GameObject.Find("none").GetComponent<Renderer>().enabled = false;
            } else if (talking) {
                GameObject.Find("whispering").GetComponent<Renderer>().enabled = false;
                GameObject.Find("none").GetComponent<Renderer>().enabled = false;
                GameObject.Find("talking").GetComponent<Renderer>().enabled = true;
            } else
            {
                GameObject.Find("whispering").GetComponent<Renderer>().enabled = false;
                GameObject.Find("none").GetComponent<Renderer>().enabled = true;
                GameObject.Find("talking").GetComponent<Renderer>().enabled = false;
            }
            talktime = time;
        }
    }
}