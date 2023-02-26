using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < wave.GetEnemyCount(); i++)
                {
                    Instantiate(wave.GetEnemyPrefab(i),
                        wave.GetStartingWayPoint().position,
                        Quaternion.Euler(0,0,180), // Quaternion.Euler can allow the rotate 
                        transform); //with this state we can spawh enemies under of game object in unity

                    yield return new WaitForSeconds(wave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while(isLooping);
    }

    public WaveConfigSO GetCurrentWave() { return currentWave; }
}
