using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private int size;
    private List<GameObject> horizSegments, vertSegments;
    private int spacing = 1;
    public List<List<int>> dotClues;
    public List<List<int>> numberClues;
    private List<List<int>> horizSolution, vertSolution;

    public GameObject lineSegmentPrefab, gridDotPrefab, whiteDotPrefab, blackDotPrefab, numberCluePrefab;
    public PuzzleData data;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        
        //mainCam = FindAnyObjectByType<Camera>();

        if (GameManager.SelectedPuzzle != null)
        {
            size = GameManager.SelectedPuzzle.size;
            
            dotClues = new List<List<int>>();
            numberClues = new List<List<int>>();
            horizSolution = new List<List<int>>();
            vertSolution = new List<List<int>>(); 

            for (int i = 0; i < size; i++)
            {
                dotClues.Add(new List<int>(GameManager.SelectedPuzzle.dotClues[i]));
                numberClues.Add(new List<int>(GameManager.SelectedPuzzle.numberClues[i]));
                horizSolution.Add(new List<int>(GameManager.SelectedPuzzle.horizontalSolution[i]));
                vertSolution.Add(new List<int>(GameManager.SelectedPuzzle.verticalSolution[i]));
            }
        }
        else
        {
            size = 5; 
        }
            
        mainCam.transform.position = new Vector3(size / 2, size / 2, -10);
        createGrid(data); 
    }

    public void createGrid(PuzzleData data)
    {
        horizSegments = new List<GameObject>();
        vertSegments = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size - 1; j++)
            {
                horizSegments.Add(Instantiate(lineSegmentPrefab, new Vector3(i + spacing, j + 1 + spacing - .5f, 0), Quaternion.identity));
            }
        }
        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size; j++)
            {
                vertSegments.Add(Instantiate(lineSegmentPrefab, new Vector3(i + 1 + spacing - .5f, j + spacing, 0), Quaternion.Euler(0, 0, 90)));
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(gridDotPrefab, new Vector3(i + spacing, j + spacing, 0), Quaternion.identity);
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (dotClues[i][j] == 1)
                {
                    Instantiate(whiteDotPrefab, new Vector3(i + spacing, j + spacing, -1), Quaternion.identity);
                }
                else if (dotClues[i][j] == 2)
                {
                    Instantiate(blackDotPrefab, new Vector3(i + spacing, j + spacing, -1), Quaternion.identity);
                }
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size - 1; j++)
            {
                if (numberClues[i][j] != 0)
                {
                    GameObject clue = Instantiate(numberCluePrefab, new Vector3(i + spacing, j + 1 + spacing - .5f, -1), Quaternion.identity);
                    clue.GetComponentInChildren<TMPro.TMP_Text>().text = numberClues[i][j].ToString();
                }
            }
        }
    }

    public bool CheckSolution()
    {
        if (horizSegments.Count != horizSolution.Count * horizSolution[0].Count || vertSegments.Count != vertSolution.Count * vertSolution[0].Count)
            return false;
        else return true;
    }
}
