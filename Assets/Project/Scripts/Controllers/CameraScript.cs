using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;

    [Tooltip("Use only if you get camera rotation implemented")]
    public float offset;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z);
    }
}
