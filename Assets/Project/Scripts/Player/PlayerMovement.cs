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
    public bool SpeedBoost;
    public float BoostTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SpeedBoost = false;
    }
    void FixedUpdate()
    {
        LookTowardsMouse();
        if(!SpeedBoost)
        {
             rb.velocity = movement * speed;
        }
        if(SpeedBoost)
        {
            rb.velocity = movement * (speed * 2);
            StartCoroutine(SpeedBoosted());
        }
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - transform.position.z));
        mousePos.y = transform.position.y;
        Movement();
    }



    void Movement()
    {
        movement = new Vector3 (Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
    }

    void LookTowardsMouse()
    {
        transform.LookAt(mousePos);
    }


    IEnumerator SpeedBoosted()
    {
        yield return new WaitForSeconds(BoostTime);
        SpeedBoost = false;
    }
}