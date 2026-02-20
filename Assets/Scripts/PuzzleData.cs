using System.Collections.Generic;


[System.Serializable]
public class PuzzleData
{
    public int puzzleID;
    public int size;

    public int[] dotClues;
    public int[] numberClues;
    public int[] horizontalSolution;
    public int[] verticalSolution;
}


[System.Serializable]
public class PuzzleList
{
    public PuzzleData[] puzzles;
}