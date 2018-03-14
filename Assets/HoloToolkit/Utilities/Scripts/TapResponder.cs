using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity.InputModule.Tests
{
        public class TapResponder : MonoBehaviour, IInputClickHandler
        {
            public void OnInputClicked(InputClickedEventData eventData)
            {
                // Increase the scale of the object just as a response.
                gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;
                eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
            Debug.Log("Hello");
                StartCoroutine(LoadYourAsyncScene());
            Debug.Log("world");
            }
            IEnumerator LoadYourAsyncScene()
            {
                // The Application loads the Scene in the background at the same time as the current Scene.
                //This is particularly good for creating loading screens. You could also load the Scene by build //number.
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("level1-mouth");

                //Wait until the last operation fully loads to return anything
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
            }
        }
}