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

    public void BeginnerNext()
    {
        SceneManager.LoadScene("Addpractice");
    }

    public void IntermediateNext()
    {
        SceneManager.LoadScene("AddPractice_Intermediate");
    }

    public void AdvancedNext()
    {
        SceneManager.LoadScene("AddPractice_Advanced");
    }
}
