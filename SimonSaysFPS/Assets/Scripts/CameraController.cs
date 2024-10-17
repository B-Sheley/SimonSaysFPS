using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Transform cameraPosition;
    public float xSensitivity;
    public float ySensitivity;

    public Transform orientation;

    float xRotation;
    float yRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        player.gameObject.GetComponent<Rigidbody>().rotation = transform.rotation;
    }
}
