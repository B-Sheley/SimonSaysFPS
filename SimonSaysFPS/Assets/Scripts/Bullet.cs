using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
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
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("Points Gained");
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
