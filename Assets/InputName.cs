using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
// using System;

public class InputName : MonoBehaviour
{
    [SerializeField] private string apiUrl = "http://localhost:3001/api/data";
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
        StartCoroutine(CallAPI(name)); // Load scene at end of this coroutine so that it doesn't get interrupted
    }

    IEnumerator CallAPI(string name)
    {
        // Generate a random number between 1 and 999
        int user_id = Random.Range(1, 10000);

        var userdata = new
        {
            username = name,
            id = user_id,
        };

        // Serialize the JSON object to a string
        string jsonData = JsonConvert.SerializeObject(userdata);

        // Convert the JSON payload to a byte array
        byte[] byteData = Encoding.UTF8.GetBytes(jsonData);

        // Create the HttpClient
        HttpClient client = new HttpClient();

        // Send get request
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:3001/api/game-data"))
        {
            yield return www.SendWebRequest();
            Debug.Log($"Request status: {www.result}");
            Debug.Log($"Response code: {www.responseCode}");
            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);
            }
            else
            {
                Debug.Log($"Request failed with status code {www.responseCode}");
            }
        }

        // Create the HttpRequestMessage and set the content
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
        request.Content = new ByteArrayContent(byteData);
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        // Send the POST request to the API
        var task = client.SendAsync(request);

        while (!task.IsCompleted)
        {
            yield return null;
        }

        HttpResponseMessage response = task.Result;

        // Check if the request was successful (HTTP 2xx status code)
        if (response.IsSuccessStatusCode)
        {
            Debug.Log("Data sent successfully to the Node.js API");
        }
        else
        {
            Debug.LogError("Failed to send data to the Node.js API. Error: " + response.StatusCode);
        }

        // Dispose of the HttpClient instance
        client.Dispose();

        // Load next scene
        SceneManager.LoadScene("Loading_bar");
    }
}