using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleUI : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneTransitionManager = SceneTransitionManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void puzzleButton(string scene)
    {
        if (sceneTransitionManager != null)
        {
            sceneTransitionManager.loadSceneWithTransition(scene);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

}
