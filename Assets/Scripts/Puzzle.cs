using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    private int size;
    private List<GameObject> horizSegments, vertSegments;
    private int spacing = 1;
    public List<int> dotClues;
    public List<int> numberClues;
    private List<int> horizSolution, vertSolution;
    
    //public List<int> horizStatus, vertStatus;
    public GameObject lineSegmentPrefab, gridDotPrefab, whiteDotPrefab, blackDotPrefab, numberCluePrefab;
    public PuzzleData data;
    public Camera mainCam;
    public GameObject backBtn;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        //backBtn = Ga pmeObject.Find("BackButton");
        //Button btn = backBtn.GetComponent<Button>();
        //TMP_Text btnText = backBtn.GetComponentInChildren<TMP_Text>();
        //btnText.text = "Back";
        //btn.onClick.AddListener(() => BackButton());

        if (GameManager.SelectedPuzzle != null)
        {
            size = GameManager.SelectedPuzzle.size;
            
            dotClues = new List<int>();
            numberClues = new List<int>();
            horizSolution = new List<int>();
            vertSolution = new List<int>(); 

            for (int i = 0; i < GameManager.SelectedPuzzle.dotClues.Length; i++)
            {
                dotClues.Add(GameManager.SelectedPuzzle.dotClues[i]);
            }
            for (int i = 0; i <GameManager.SelectedPuzzle.horizontalSolution.Length; i++)
            {
                horizSolution.Add(GameManager.SelectedPuzzle.horizontalSolution[i]);
                vertSolution.Add(GameManager.SelectedPuzzle.verticalSolution[i]);
            }
            for (int i = 0; i < GameManager.SelectedPuzzle.numberClues.Length; i++) 
            {
                numberClues.Add(GameManager.SelectedPuzzle.numberClues[i]);
            }

            if (size > 5) mainCam.orthographicSize = 4;
            mainCam.transform.position = new Vector3((size + 1)/ 2f, (size + 1)/ 2f, -10);
            createGrid(data); 
        }
        else
        {
            return; 
        }
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
                //horizStatus.Add(0);
                //if (horizSegments.Last().TryGetComponent(out LineSegment lineSegment))
                //{
                //    lineSegment.setInfo(i, j, true);
                //}

            }
        }
        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size; j++)
            {
                vertSegments.Add(Instantiate(lineSegmentPrefab, new Vector3(i + 1 + spacing - .5f, j + spacing, 0), Quaternion.Euler(0, 0, 90)));
                //vertStatus.Add(0);
                //if (vertSegments.Last().TryGetComponent(out LineSegment lineSegment))
                //{
                //    lineSegment.setInfo(i, j, false);
                //}
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(gridDotPrefab, new Vector3(i + spacing, j + spacing, 0), Quaternion.identity);
                
                if (dotClues[i * size + j] == 1)
                {
                    Instantiate(whiteDotPrefab, new Vector3(j + spacing, i + spacing, 0), Quaternion.identity);
                }
                else if (dotClues[i * size + j] == 2)
                {
                    Instantiate(blackDotPrefab, new Vector3(j + spacing, i + spacing, 0), Quaternion.identity);
                }
            }
        }
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (numberClues[i * size + j] != -1)
                {
                    if (i == 0) //top
                    {
                        GameObject clue = Instantiate(numberCluePrefab, new Vector3(j + spacing, size + 0.5f), Quaternion.identity);
                        clue.GetComponentInChildren<TMPro.TMP_Text>().text = numberClues[i * size + j].ToString();
                    }
                    else if (i == 1) //left
                    {
                        GameObject clue = Instantiate(numberCluePrefab, new Vector3(0.5f, size - j, 0), Quaternion.identity);
                        clue.GetComponentInChildren<TMPro.TMP_Text>().text = numberClues[i * size + j].ToString();
                    }
                }
            }
        }
    }

    public void  CheckSolution()
    {
        List<int> horiz = new List<int>();
        List<int> vert = new List<int>();
        foreach (GameObject segment in horizSegments)
        {
            segment.TryGetComponent(out LineSegment lineSegment);
            horiz.Append(lineSegment.isClicked ? 1 : 0);
        }

        foreach (GameObject segment in vertSegments)
        {
            segment.TryGetComponent(out LineSegment lineSegment);
            horiz.Append(lineSegment.isClicked ? 1 : 0);
        }


        if (data.checkSolution(horiz, vert))
        {
            Debug.Log("correct!")
        }
    }

    public void BackButton()
    {
        Debug.Log("back");
        GameManager.SelectedPuzzle = null;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
}
