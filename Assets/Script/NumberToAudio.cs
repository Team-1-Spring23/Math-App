using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberToAudio : MonoBehaviour
{

    public AudioSource one;
    public AudioSource two;
    public AudioSource three;
    public AudioSource four;
    public AudioSource five;
    public AudioSource six;
    public AudioSource seven;
    public AudioSource eight;
    public AudioSource nine;
    public AudioSource ten;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAudioForNumber(int number)
    {
        switch (number)
        {
            case 1: one.Play(); break;
            case 2: two.Play(); break;
            case 3: three.Play(); break;
            case 4: four.Play(); break;
            case 5: five.Play(); break;
            case 6: six.Play(); break;
            case 7: seven.Play(); break;
            case 8: eight.Play(); break;
            case 9: nine.Play(); break;
            case 10: ten.Play(); break;

            default:
                break;
        }
    }
}
