using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<string> colorList = new List<string>();
    public string currentColor;
    public string newColor;
    private int colorNum;
    [SerializeField] TextMeshProUGUI currentColorText;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI currentHighScoreText;
    [SerializeField] Target targetRed;
    [SerializeField] Target targetBlue;
    [SerializeField] Target targetGreen;
    [SerializeField] Target targetYellow;
    public bool currentColorCheck;
    public int currentListInum = 0;
    public int score = 0;
    public int highScore = 0;
    public AudioSource scoreSource;
    public AudioClip scoreClip;
    public AudioSource failSource;
    public AudioClip failClip;

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
        currentScoreText.text = "Score: " + score.ToString();
        currentHighScoreText.text = "High Score: " + highScore.ToString();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(displayColorList());
        }
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
        StartCoroutine(displayColorList());
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
        targetRed.gameObject.GetComponent<Target>().SpeedIncrease();
        targetBlue.gameObject.GetComponent<Target>().SpeedIncrease();
        targetGreen.gameObject.GetComponent<Target>().SpeedIncrease();
        targetYellow.gameObject.GetComponent<Target>().SpeedIncrease();
        score += 1;
        scoreSource.PlayOneShot(scoreClip);
        currentListInum = 1;
        currentColor = colorList[0];
        colorChange();
        
    }

    public void newColorListOnLoss()
    {
        targetRed.gameObject.GetComponent<Target>().SpeedReset();
        targetBlue.gameObject.GetComponent<Target>().SpeedReset();
        targetGreen.gameObject.GetComponent<Target>().SpeedReset();
        targetYellow.gameObject.GetComponent<Target>().SpeedReset();
        if (score > highScore)
        {
            highScore = score;
        }
        score = 0;
        failSource.PlayOneShot(failClip);
        //StopCoroutine(displayColorList());
        StopAllCoroutines();
        colorList.Clear();
        colorChange();
        currentListInum = 0;
        currentColor = colorList[currentListInum];
        currentListInum = 1;

    }

    public IEnumerator displayColorList()
    {
        Debug.Log("displayColorList"); 
        for (int i = 0; i < colorList.Count; i++)
        {
            yield return new WaitForSeconds(.5f);
            currentColorText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.35f);
            currentColorText.text = colorList[i];
            yield return new WaitForSeconds(.35f);
            currentColorText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(.5f);
        currentColorText.gameObject.SetActive(false);
    }

}
