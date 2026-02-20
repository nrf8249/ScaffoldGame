using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject titlePanel;      
    public GameObject levelSelectPanel; 

    [Header("Level List Settings")]
    public GameObject buttonPrefab;
    public Transform contentParent;

    public PuzzleList puzzleList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titlePanel.SetActive(true);       
        levelSelectPanel.SetActive(false); 

        PuzzleList puzzleList;
        string path = "Assets/Scripts/Puzzles.json";
        if (File.Exists(path))
        {
            string json = r.ReadToEnd();        
            puzzleList = JsonUtility.FromJson<PuzzleList>(json);
            string json = r.ReadToEnd();        
            puzzleList = JsonUtility.FromJson<PuzzleList>(json);

        }
    {
        foreach (PuzzleData data in list.puzzles)
        {
            GameObject newBtn = Instantiate(buttonPrefab, contentParent);
            TMP_Text btnText = newBtn.GetComponentInChildren<TMP_Text>();
            if (btnText != null) btnText.text = "Level " + data.puzzleID;

            Button btn = newBtn.GetComponent<Button>();
            btn.onClick.AddListener(() => OnLevelClicked(data));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
