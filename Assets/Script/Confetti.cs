using UnityEngine;
using UnityEngine.SceneManagement;

public class Confetti : MonoBehaviour
{
    // Update is called once per frame
   public void Next()
    {
        SceneManager.LoadScene("Adding_puzzle");
    }
    public void QuizNext()
    {
        SceneManager.LoadScene("Adding_Quiz");
    }

    public void FunNext()
    {
        SceneManager.LoadScene("Random Objects");
    }
}
