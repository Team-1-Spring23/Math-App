using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    static SceneTransitionManager instance;
    static Animator animator;

    private Coroutine coroutineMessage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            animator = GetComponent<Animator>();
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public static SceneTransitionManager getInstance()
    {
        if (instance == null)
        {
            GameObject sceneTransitionPrefab = Resources.Load("SceneTransition") as GameObject;
            GameObject go = GameObject.Instantiate(sceneTransitionPrefab);
            instance = go.GetComponent<SceneTransitionManager>();
            animator = go.GetComponent<Animator>();
            DontDestroyOnLoad(go);
        }
        return instance;
    }

    public void loadSceneWithTransition(string scene)
    {
        if (animator != null)
        {
            if (null != coroutineMessage)
            {
                StopCoroutine(coroutineMessage);
            }
            coroutineMessage = StartCoroutine(loadSceneAfterWait(scene, 0.95f));
        }
        else
        {
            SceneManager.LoadScene(scene);
        }

    }

    private IEnumerator loadSceneAfterWait(string scene, float time)
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(time);
        SceneManager.LoadSceneAsync(scene);
        yield return new WaitForSeconds(0.25f);
        animator.SetTrigger("Open");
    }

}
