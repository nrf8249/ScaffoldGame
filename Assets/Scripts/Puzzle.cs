using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private int size;
    private List<GameObject> horizSegments, vertSegments;
    private int spacing = 1;
    private List<GameObject> dots;

    public GameObject lineSegmentPrefab, gridDot;


    // Start is called before the first frame update
    void Start()
    {
        size = 5;
        createGrid();
    }

    void createGrid()
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
                Instantiate(gridDot, new Vector3(i + spacing, j + spacing, 0), Quaternion.identity);
            }
        }

    }
}
