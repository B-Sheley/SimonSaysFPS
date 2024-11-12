using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPosition;
    [SerializeField] GameObject bulletObject;
    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = Instantiate(bulletObject, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            //bullet.GetComponent<Transform>().rotation = (0f, 0f, 0f);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.forward * bulletSpeed;
        }
    }
}
