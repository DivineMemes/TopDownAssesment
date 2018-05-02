using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    PlayerMovement moveScript;
    PooledObject pooledObject;
    void Start()
    {
        pooledObject = GetComponent<PooledObject>();
        //moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
            moveScript = other.collider.GetComponent<PlayerMovement>();
           
            moveScript.activateSpeedBoost();
            //moveScript.SpeedBoost = true;
            pooledObject.returnToPool();    
        //Destroy(gameObject);
        }
    }
}
