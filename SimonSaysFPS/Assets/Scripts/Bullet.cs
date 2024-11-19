using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Target target;
    private float lifeTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime >= 2) { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }
}
