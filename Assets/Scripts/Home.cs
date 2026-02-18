using System;
using System.IO;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PuzzleList puzzleList;
        using (StreamReader r = new StreamReader("Assets/Scripts/Puzzles.json"))
        {
            string json = r.ReadToEnd();        
            puzzleList = JsonUtility.FromJson<PuzzleList>(json);

        }

        print("Home start");
        print(puzzleList.puzzles[0].size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
