using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] string targetColor;
    [SerializeField] GameObject gameManager;
    public float moveSpeed = 1f;
   


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
        Destroyed();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameManager.GameObject().GetComponent<GameManager>().currentColor == targetColor)
        {
            gameManager.GetComponent<GameManager>().colorListIterate();
            Destroyed();
        }
        else if(collision.gameObject.tag == "Bullet" && gameManager.GameObject().GetComponent<GameManager>().currentColor != targetColor)
        {
            gameManager.GetComponent<GameManager>().newColorListOnLoss();
            Destroyed();
        }
    }

    public void Destroyed()
    {
        transform.position = new Vector3 (Random.Range(-48,49), Random.Range(2, 8), Random.Range(9,53));
    }

}
