using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float spawnOffsetX = -5;

    void Start()
    {
        StartCoroutine(SpawnWall());
    }

    IEnumerator SpawnWall()
    {
        while (player != null)
        {
            yield return new WaitForSeconds(2.0f);
            Vector3 spawnLocation = player.transform.position;
            spawnLocation.x += spawnOffsetX;
            spawnLocation.y = Random.Range(-1f, 4f);
            Instantiate(spawnPrefab, spawnLocation, Quaternion.identity);   
        }
    }
}
    