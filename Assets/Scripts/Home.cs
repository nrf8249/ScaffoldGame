using System;
using System.IO;
using UnityEngine;

public class Home : MonoBehaviour
{
    public PuzzleList puzzleList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadPuzzles();
        CreateButtons();
    }

    void LoadPuzzles()
    {
        using (StreamReader r = new StreamReader("Assets/Scripts/Puzzles.json"))
        {
            string json = r.ReadToEnd();        
            puzzleList = JsonUtility.FromJson<PuzzleList>(json);
        }

        print("Home start");
        print(puzzleList.puzzles[0].size);
    }

    void CreateButtons()
    {
        foreach (PuzzleData puzzle in puzzleList.puzzles)
        {
            

        }
    }
}
