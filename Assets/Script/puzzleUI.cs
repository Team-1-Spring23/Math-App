using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleUI : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void puzzleButton(string scene)
    {
        if (endingSceneTransition != null)
        {
            endingSceneTransition.SetActive(true);
            Invoke("disableEndTransition", 3f);

            StartCoroutine(loadSceneAfterWait(scene, 0.83f));
        }
        else
        {
            SceneManager.LoadScene(scene);
        }

    }

    private IEnumerator loadSceneAfterWait(string scene, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    private void disableStartTransition()
    {
        startingSceneTransition.SetActive(false);
    }

    private void disableEndTransition()
    {
        endingSceneTransition.SetActive(false);
    }
}
