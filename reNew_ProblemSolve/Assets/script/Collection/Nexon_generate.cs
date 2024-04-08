using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexon_generate : MonoBehaviour
{
    int sumSelfNum;

    static int selfNum(int n)
    {
        int sum = n;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }


    void Start()
    {
        HashSet<int> selfNumbers = new HashSet<int>();

        for (int i = 1; i <= 5000; i++)
        {
            selfNumbers.Add(i);
        }

        for (int i = 1; i <= 5000; i++)
        {
            selfNumbers.Remove(selfNum(i));
        }

        List<int> sortedSelfNumbers = new List<int>(selfNumbers);
        sortedSelfNumbers.Sort();

        foreach (int selfNumber in sortedSelfNumbers)
        {
            Debug.Log(selfNumber);
            sumSelfNum += selfNumber;
        }

        Debug.Log(sumSelfNum);
    }

    void Update()
    {
        
    }
}
