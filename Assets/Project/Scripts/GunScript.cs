using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    Vector3 mousePos;

    void FixedUpdate()
    {
        LookTowardsMouse();
    }
    void LookTowardsMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - transform.position.z));
        mousePos.y = transform.position.y;
        // int mousex =
        transform.LookAt(mousePos);
        Debug.DrawLine(transform.position, Input.mousePosition);
    }

}
