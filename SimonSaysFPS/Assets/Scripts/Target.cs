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
    private int moveNum;
    private Vector3 movePos;
   


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
        //if(doneMoving == true)
        //{
        //    StartCoroutine(moveAround(Random.Range(-2, 3), Random.Range(-2, 3)));
        //}

        movePos = new Vector3(transform.position.x, transform.position.y + Random.Range(-2, 3), transform.position.z + Random.Range(-2, 3));
        transform.position = Vector3.MoveTowards(transform.position, movePos, moveSpeed);

        //moveNum = Random.Range(1, 5);
        //transform.Translate(Random.Range(-1, 2) * Vector3.right * moveSpeed * Time.deltaTime);
        //transform.Translate(Random.Range(-1, 2) * Vector3.up * moveSpeed * Time.deltaTime);
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
        //doneMoving = false;
        //moveNum = Random.Range(15, 25);
        //yield return new WaitForSeconds(.1f);
        //for (int i = 0; i < moveNum; i++)
        //{
        //    transform.Translate(r * Vector3.right * moveSpeed * Time.deltaTime);
        //    transform.Translate(u * Vector3.up * moveSpeed * Time.deltaTime);
        //}
        //yield return new WaitForSeconds(.1f);
        //doneMoving = true;

        doneMoving = false;
        yield return new WaitForSeconds(.25f);
        movePos = new Vector3(transform.position.x, transform.position.y + r, transform.position.z + u);
        transform.position = Vector3.MoveTowards(transform.position, movePos, moveSpeed);
        yield return new WaitForSeconds(.25f);
        doneMoving = true;



    }

}
