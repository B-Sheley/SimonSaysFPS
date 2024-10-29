using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<string> colorList = new List<string>();
    public string currentColor;
    public string newColor;
    private int colorNum;
    [SerializeField] TextMeshProUGUI currentColorText;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI currentHighScoreText;
    public bool currentColorCheck;
    public int currentListInum = 0;
    public int score = 0;
    public int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        colorChange();
        currentColor = colorList[currentListInum];
        currentListInum++;
    }

    // Update is called once per frame
    void Update()
    {
        currentColorText.text = "Color: " + currentColor;
        currentScoreText.text = "Score: " + score.ToString();
        currentHighScoreText.text = "High Score: " + highScore.ToString();
    }

    public void colorChange() {
        colorNum = Random.Range(1, 5);
        if(colorNum == 1) { newColor = "Red"; }
        else if (colorNum == 2) { newColor = "Blue"; }
        else if (colorNum == 3) { newColor = "Green"; }
        else { newColor = "Yellow"; }
        colorAdd(newColor);
    }

    private void colorAdd(string s) {
        Debug.Log("Start new List");
        colorList.Add(s);
        for(int i = 0; i < colorList.Count; i++)
        {
            Debug.Log(colorList[i]);
        }
    
    }

    public void colorListIterate()
    {
        if(currentListInum < colorList.Count)
        {
            currentColor = colorList[currentListInum];
            currentListInum++;
        }
        else 
        { 
            colorListRestartCurrentList(); 
            
        }
    }

    private void colorListRestartCurrentList()
    {
        score += 1;
        currentListInum = 1;
        currentColor = colorList[0];
        colorChange();
    }

    public void newColorListOnLoss()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        score = 0;
        colorList.Clear();
        colorChange();
        currentListInum = 0;
        currentColor = colorList[currentListInum];
        currentListInum = 1;

    }

}
