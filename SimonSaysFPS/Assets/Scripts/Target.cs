using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] string targetColor;
    

    private void Awake()
    {
        if(targetColor == "Red")
        {
            gameObject.GetComponent<Light>().color = Color.red;
        }
        else if(targetColor == "Blue")
        {
            gameObject.GetComponent<Light>().color = Color.blue;
        }
        else if (targetColor == "Green")
        {
            gameObject.GetComponent<Light>().color = Color.green;
        }
        else if (targetColor == "Yellow")
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(targetColor + "Hit");
        }
    }

}