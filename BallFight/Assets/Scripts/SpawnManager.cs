using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9.0f;
    public int enemyCount, numberOfEnemies = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        //Return length of Enemys
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Instantiate(powerUp, GenereateSpawnPosition(), powerUp.transform.rotation);
            numberOfEnemies++;
            SpawnEnemyWave();  
        }
            
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenereateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenereateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPosition;
    }
}
