using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddingFun : MonoBehaviour
{
    [SerializeField] private string Adding_Fun = "Adding_Fun";

    public void practiceButton()
    {

        SceneManager.LoadScene(Adding_Fun);

    }
}
