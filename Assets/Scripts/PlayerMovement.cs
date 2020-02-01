using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerDetection playerDetection;
    public float speed = 1.0f;

    private float h = 0;
    private float v = 0;
    private Rigidbody rb;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        if (canMove)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(h, 0, v) * speed;
        }
    }
}
