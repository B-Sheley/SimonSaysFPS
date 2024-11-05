using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] string targetColor;
    [SerializeField] GameObject gameManager;
    [SerializeField] float moveSpeed;
    private bool doneMoving = true;
   


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
        if(doneMoving == true)
        {
            StartCoroutine(moveAround(Random.Range(-1, 2), Random.Range(-1, 2)));
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameManager.GameObject().GetComponent<GameManager>().currentColor == targetColor)
        {
            gameManager.GetComponent<GameManager>().colorListIterate();
        }
        else if(collision.gameObject.tag == "Bullet" && gameManager.GameObject().GetComponent<GameManager>().currentColor != targetColor)
        {
            gameManager.GetComponent<GameManager>().newColorListOnLoss();
        }
        
    }

    public IEnumerator moveAround(int r, int u)
    {
        doneMoving = false;
        yield return new WaitForSeconds(.025f);
        transform.Translate(r * Vector3.right * moveSpeed * Time.deltaTime);
        transform.Translate(u * Vector3.up * moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(.025f);
        doneMoving = true;



    }

}
