using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    PlayerMovement moveScript;

    void Start()
    {
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
	void Update ()
    {
        AttractAttention();	
	}

    void AttractAttention()
    {
        gameObject.transform.rotation *= Random.rotation;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            moveScript.SpeedBoost = true;
            Destroy(gameObject);
        }
    }
}
