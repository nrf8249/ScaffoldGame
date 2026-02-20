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

    public bool checkSolution(int [] horizontal, int[] vertical)
    {
        return horizontal == this.horizontalSolution && vertical == this.verticalSolution;
    }
}


[System.Serializable]
public class PuzzleList
{
    public PuzzleData[] puzzles;
}