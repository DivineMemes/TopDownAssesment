using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUp;
    public int spawnCount;
    float spawnTime;
    ObjectPool[] pool;
    public float minSpawnTime;
    public float maxSpawnTime;


    void Start()
    {
        pool = GetComponents<ObjectPool>();
        //for(int i = 0; i < )
        powerUp = powerUpsFromFolder();
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(SpawnTimer());
    }


    GameObject[] powerUpsFromFolder()
    {

        Object[] things = Resources.LoadAll("PowerUps/");
        GameObject[] retval = new GameObject[things.Length];
        for (int i = 0; i < retval.Length; i++)
        {
            retval[i] = (GameObject)things[i];
        }
        return retval;

    }



    void poolSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnedPowerUp = pool[Random.Range(0, 3)].getObject();
            //spawnedEnemy.transform.position = Random.insideUnitCircle;
            Vector3 spawnPos = Random.insideUnitSphere * 20;
            spawnPos.y = 1;
            spawnedPowerUp.transform.position = spawnPos;
        }
    }

    void Spawn(GameObject chosenPowerUp)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnedPowerUp = Instantiate(chosenPowerUp);
            Vector3 spawnPos = Random.insideUnitSphere * 20;
            spawnPos.y = 1;
            spawnedPowerUp.transform.position = spawnPos;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            //
            GameObject powerUpToSpawn = powerUp[Random.Range(0, 3)];
            poolSpawn();
        }
    }
}
