using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class backButton : MonoBehaviour
{
    [SerializeField] private string screen_name;
    [SerializeField] private GameObject endingSceneTransition;
    public void backButtonFns()
   {
        if (endingSceneTransition != null)
        {
            endingSceneTransition.SetActive(true);
            Invoke("disableEndTransition", 3f);

            StartCoroutine(loadSceneAfterWait(screen_name, 0.83f));
        }
        else
        {
            SceneManager.LoadScene(screen_name);
        }
    }

    private IEnumerator loadSceneAfterWait(string scene, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    private void disableEndTransition()
    {
        endingSceneTransition.SetActive(false);
    }
}
