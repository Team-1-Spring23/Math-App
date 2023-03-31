using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions : MonoBehaviour
{
    public (int, int) GetTwoRandomSum(int num) // Return tuple of two random numbers that sum to something between 2 and num (num should be under 20)
    {
        int firstNum = Random.Range(1, num); // Random integer between 1 and num - 1
        int nextNum = Random.Range(1, num + 1 - firstNum); // Ensure sum is no more than num

        return (firstNum, nextNum);
    }

    public (int, int, int) GetSumOptions(int firstNum, int nextNum, int num) // Return 3 random options between 1 and num, one of which is the correct sum
    {
        int answer = firstNum + nextNum;

        if (answer < 2 || answer > num)
        {
            throw new System.Exception("GetSumOptions received invalid values to sum");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // 1 through 9 will always be possibilities for the correct answer
        if (num > 9) // Include 11 through 19 as possibilites if num is above 9
        {
            for (int i = 10; i < 20; ++i)
            {
                possibilities.Add(i);
            }
        }

        possibilities.Remove(answer); // Ensure only one correct answer offered

        // Get first incorrect option
        int firstOptionIndex = Random.Range(0, possibilities.Count);
        int firstOption = possibilities[firstOptionIndex];

        // Ensure next incorrect option is different from the first one
        possibilities.Remove(firstOption);

        // Get next incorrect option
        int nextOptionIndex = Random.Range(0, possibilities.Count);
        int nextOption = possibilities[nextOptionIndex];

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption };
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        return (options[0], options[1], options[2]);
    }

    public IEnumerator TransitionObject(GameObject obj) // Move an object offscreen to the left then inscreen from the right
    {
        Vector3 originalPos = obj.transform.position;
        Vector3 leftOffScreen = originalPos + new Vector3(-1 * Screen.width, 0, 0);
        Vector3 rightOffScreen = originalPos + new Vector3(Screen.width, 0, 0);
        float elapsedTime = 0;
        int moveSpeed = 8;

        while (elapsedTime < 1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = rightOffScreen; // Now instantly move it to the right side of the screen to prepare to move it back in

        while (elapsedTime < 2)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, originalPos, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = originalPos; // ensure end at original position since Lerp is inexact

        yield return null;
    }
}
