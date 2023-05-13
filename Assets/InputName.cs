using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class InputName : MonoBehaviour
{
    [SerializeField] private string serverLocation = "http://localhost:3001/api/user-data";
    public TMP_InputField nameField;
    // Start is called before the first frame update
    void Start()
    {
        nameField.onSubmit.AddListener(nextScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void nextScreen(string name)
    {
        Debug.Log(name);
        StartCoroutine(postData(name));
        //SceneManager.LoadScene("Loading_bar");
    }

    private IEnumerator postData(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("120", data);
        using (UnityWebRequest www = UnityWebRequest.Post(serverLocation, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}