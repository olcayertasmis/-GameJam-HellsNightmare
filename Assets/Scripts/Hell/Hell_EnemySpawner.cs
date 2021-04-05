using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public Transform[] spawnposition;
    public static int enemyCount;

    void Start()
    {
        Spawn(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 1 || enemyCount == 0){
            Spawn(3);
        }
    }

    public void Spawn(int spawnCount){
        for(int i = spawnCount; i > 0; i--){
            int randomNumber = Random.Range(0, 4);
            enemyCount++;
            GameObject enemy = Instantiate(EnemyPrefab,spawnposition[randomNumber].position,spawnposition[randomNumber].rotation);
        }
    }
}
