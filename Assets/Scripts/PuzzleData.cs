using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PuzzleData
{
    public int puzzleID;
    public int size;

    public int[] dotClues;
    public int[] numberClues;
    public int[] horizontalSolution;
    public int[] verticalSolution;

    public bool checkSolution(List<int> horiz, List<int> vert)
    {
        for (int i = 0; i < horiz.Count; i++)
        {
            if (horiz[i] != horizontalSolution[i]) return false;
        }

        for (int i = 0; i < vert.Count; i++)
        {
            if (horiz[i] != verticalSolution[i]) return false;
        }

        return true;
    }
}

[System.Serializable]
public class PuzzleList
{
    public PuzzleData[] puzzles;
}
