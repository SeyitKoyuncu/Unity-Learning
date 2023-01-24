using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startDelay = 2.0f;
    private float repeatTime = 1.5f;
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
        Instantiate(animalPrefabs[animalIndex], new Vector3(spawnLocationX, 0, 20), animalPrefabs[animalIndex].transform.rotation);        
    }
}
