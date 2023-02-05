using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HoleController : MonoBehaviour
{
    public List<Transform> holes;
    [SerializeField] private GameObject carrotPrefab, montonPrefab;
    [SerializeField] private int filledHoles;
    public List<int> FilledHolesList;

    private void Start()
    {
        List<int> numbers = GenerateUniqueRandomNumbers(0, holes.Count, filledHoles);
        FilledHolesList = numbers;

        for (int i = 0; i < holes.Count; i++)
        {
            if (numbers.Contains(i))
            {
                Instantiate(montonPrefab, holes[i]);
                Instantiate(carrotPrefab, holes[i]);
            }
        }
    }
    
    private List<int> GenerateUniqueRandomNumbers(int minValue, int maxValue, int listSize)
    {
        Random random = new Random();
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < listSize)
        {
            int number = random.Next(minValue, maxValue);
            if (!numbers.Contains(number))
            {
                numbers.Add(number);
            }
        }
        return new List<int>(numbers);
    }
}
