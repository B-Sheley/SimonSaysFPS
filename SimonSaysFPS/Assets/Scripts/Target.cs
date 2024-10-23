using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] string TargetColor;
    

    private void Awake()
    {
        if(TargetColor == "Red")
        {
            gameObject.GetComponent<Light>().color = Color.red;
        }
        else if(TargetColor == "Blue")
        {
            gameObject.GetComponent<Light>().color = Color.blue;
        }
        else if (TargetColor == "Green")
        {
            gameObject.GetComponent<Light>().color = Color.green;
        }
        else if (TargetColor == "Yellow")
        {
            gameObject.GetComponent<Light>().color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Light>().color = Color.white;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log(TargetColor);
    }
}
