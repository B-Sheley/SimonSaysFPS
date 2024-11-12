using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] string targetColor;
    [SerializeField] GameObject gameManager;
    public float moveSpeed = 1f;
    public float originMoveSpeed = 1f;
    private int movePoint = -1;




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
            gameObject.GetComponent<Light>().color = Color.black;
        }
        originMoveSpeed = moveSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroyed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movePoint * Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.x <= -50)
        {
            Destroyed();
        }
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
        transform.position = new Vector3 (Random.Range(-20,45), Random.Range(2, 8), Random.Range(10,50));
    }

    public void SpeedIncrease()
    {
        moveSpeed += 1;
    }

    public void SpeedReset()
    {
        moveSpeed = originMoveSpeed;
    }

}
