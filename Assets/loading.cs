using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    [SerializeField]
    public GameObject loadingPanel;
    public Slider loadingSlider;
    public Text progressText;
    public void Start(){
        StartCoroutine(LoadAsyncOperation(1));
    }  


    IEnumerator LoadAsyncOperation (int sceneIndex){
       yield return new WaitForSeconds(3);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanel.SetActive(true);
        
        while (!gameLevel.isDone )
        {
            float progress = Mathf.Clamp01(gameLevel.progress / .9f);
            loadingSlider.value = progress;  
            
            progressText.text = progress * 100 + "%";

            yield return null; 
        }
    
    }
}