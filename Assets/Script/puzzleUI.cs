using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleUI : MonoBehaviour
{
    private admob AdMob;
    // Start is called before the first frame update
    void Start()
    {
        AdMob = FindObjectOfType<admob>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void puzzleButton(string scene)
    {
        if (SceneManager.GetActiveScene().name == "home_screen") // Show interstitial ad when moving from home screen to a game
        {
            AdMob.ShowInterstitialAd();
            AdMob.interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                SceneManager.LoadScene(scene);
            };
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
