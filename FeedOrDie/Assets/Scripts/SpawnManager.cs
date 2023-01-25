using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startDelay = 2.0f;
    private float repeatTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Call SpawnRandomAnimal method every 1.5 second
        //public void InvokeRepeating(string methodName, float time, float repeatRate);
        InvokeRepeating("SpawnRandomAnimal", startDelay, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, 3);
        int spawnLocationX = Random.Range(-21, 23);
        int spawnLocationZ = Random.Range(13, 32);
        float spawnRotation = Random.Range(90.0f, 270.0f);
        Vector3 newRotation = new Vector3(0, spawnRotation, 0);
        Instantiate(animalPrefabs[animalIndex], new Vector3(spawnLocationX, 0, spawnLocationZ), Quaternion.Euler(newRotation));
    }
}
