using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public AudioSource source; 
    public AudioClip clip;

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
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletObject, bulletSpawnPosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.forward * bulletSpeed;
            source.PlayOneShot(clip);

        }
    }
}
