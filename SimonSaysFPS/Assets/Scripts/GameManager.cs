using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<string> colorList = new List<string>();
    public string currentColor;
    private int colorNum;
    [SerializeField] TextMeshProUGUI currentColorText;
    private int currentColorNum = 0;
    public bool currentColorCheck;

    // Start is called before the first frame update
    void Start()
    {
        colorChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            colorChange();
        }
    }

    public void colorChange() {
        colorNum = Random.Range(1, 5);
        if(colorNum == 1) { currentColor = "Red"; }
        else if (colorNum == 2) { currentColor = "Blue"; }
        else if (colorNum == 3) { currentColor = "Green"; }
        else { currentColor = "Yellow"; }
        currentColorText.text = currentColor;
        colorAdd(currentColor);
    }

    private void colorAdd(string s) {
        Debug.Log("Start new List");
        colorList.Add(s);
        for(int i = 0; i < colorList.Count; i++)
        {
            Debug.Log(colorList[i]);
        }
    
    }

    public void colorListCheck()
    {
       
    }

    private void colorListDisplay()
    {

    }


}
