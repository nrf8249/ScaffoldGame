using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PuzzleList puzzleList = JsonUtility.FromJson<PuzzleList>("Puzzles.json");

        print(puzzleList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
