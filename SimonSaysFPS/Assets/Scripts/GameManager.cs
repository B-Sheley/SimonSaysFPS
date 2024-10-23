using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<string> colorList = new List<string>();
    private string currentColor;
    private int colorNum;
    [SerializeField] TextMeshProUGUI currentColorText;

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

    private void colorChange() {
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


}
