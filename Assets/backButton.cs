using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    [SerializeField] private string screen_name;
    private SceneTransitionManager sceneTransitionManager;

    void Start()
    {
        sceneTransitionManager = SceneTransitionManager.getInstance();
    }

    public void backButtonFns()
    {
        if (sceneTransitionManager != null)
        {
            sceneTransitionManager.loadSceneWithTransition(screen_name);
        }
        else
        {
            SceneManager.LoadScene(screen_name);
        }
    }

}
