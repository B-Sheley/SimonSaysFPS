using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float groundDrag;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 Direction;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput();
        SpeedMax();

        rb.drag = groundDrag;

    }

    private void FixedUpdate()
    {
        playerMove();

    }

    private void playerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void playerMove()
    {
        Direction = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(Direction.normalized * Speed * 10f, ForceMode.Force);

    }

    private void SpeedMax()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > Speed)
        {
            Vector3 limitedVel = flatVel.normalized * Speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
