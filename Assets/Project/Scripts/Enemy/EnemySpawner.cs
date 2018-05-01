using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public int spawnCount;
    float spawnTime;
    ObjectPool[] pool;


    void Start()
    {
        pool = GetComponents<ObjectPool>();
        //for(int i = 0; i < )
        enemy = enemiesFromFolder();
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(SpawnTimer());
    }


    GameObject[] enemiesFromFolder()
    {

        Object[] things = Resources.LoadAll("Enemies/");
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
            GameObject spawnedEnemy = pool[Random.Range(0, 3)].getObject();
            //spawnedEnemy.transform.position = Random.insideUnitCircle;
            Vector3 spawnPos = Random.insideUnitSphere * 20;
            spawnPos.y = 1;
            spawnedEnemy.transform.position = spawnPos;
        }
    }

    void Spawn(GameObject chosenEnemy)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnedEnemy = Instantiate(chosenEnemy);
            Vector3 spawnPos = Random.insideUnitSphere * 20;
            spawnPos.y = 1;
            spawnedEnemy.transform.position = spawnPos;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            spawnTime = Random.Range(2, 5);
            //Debug.Log(spawnTime);
            yield return new WaitForSeconds(spawnTime);
            //
            GameObject enemyToSpawn = enemy[Random.Range(0, 3)];
            poolSpawn();
            //Spawn(enemyToSpawn);
        }
        //Random.insideUnitCircle();
    }

}
