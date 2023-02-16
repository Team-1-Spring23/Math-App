using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSum : MonoBehaviour
{
    public (int, int) GetTwoRandomSum() // Return tuple of two random numbers that sum to something between 2 and 9
    {
        int firstNum = Random.Range(1, 9); // Random integer between 1 and 8
        int nextNum = Random.Range(1, 10 - firstNum); // Ensure sum is no more than 9

        return (firstNum, nextNum);
    }

    public (int, int, int) GetSumOptions(int firstNum, int nextNum) // Return 3 random options between 1 and 9, one of which is the correct sum
    {
        int answer = firstNum + nextNum;
        
        if (answer < 2 || answer > 9)
        {
            throw new System.Exception("GetSumOptions received invalid values to sum");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        possibilities.Remove(answer); // Ensure only one correct answer offered

        int firstOptionIndex = Random.Range(0, possibilities.Count);
        int nextOptionIndex = Random.Range(0, possibilities.Count);
        int firstOption = possibilities[firstOptionIndex];
        int nextOption = possibilities[nextOptionIndex];

        var options = new List<int>() { answer, firstOption, nextOption };

        // Shuffle options before returning them
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
    /*
    public void Test()
    {
        var nums = GetTwoRandomSum();
        Debug.Log("First num in sum: " + nums.Item1);
        Debug.Log("Second num in sum: " + nums.Item2);

        var options = GetSumOptions(nums.Item1, nums.Item2);
        Debug.Log("Option 1: " + options.Item1);
        Debug.Log("Option 2: " + options.Item2);
        Debug.Log("Option 3: " + options.Item3);
    }
    */
}
