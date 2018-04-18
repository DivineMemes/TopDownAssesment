using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 rightDir;
    Vector3 forwardDir;
    Vector3 movement;


    Rigidbody rb;


    [Tooltip ("make this number small it scales drastically")]
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        LookTowardsMouse();
        rb.velocity = movement * speed;
    }

    void Update()
    {
        Movement();
    }



    void Movement()
    {
        movement = new Vector3 (Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
    }

    void LookTowardsMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - transform.position.z));
        mousePos.y = transform.position.y;
        transform.LookAt(mousePos);
    //    Debug.DrawLine(transform.position, Input.mousePosition);
    }
}