using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddingQuiz : MonoBehaviour
{
    [SerializeField] private string Adding_Quiz = "Adding_Quiz";

    public void practiceButton()
    {

        SceneManager.LoadScene(Adding_Quiz);

    }
}
