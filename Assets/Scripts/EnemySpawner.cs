using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    //spwan enemies along with waves each time game starts
    IEnumerator  SpawnEnemyWaves()
    {
        //using coruotines to get enemies at varied rate
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    //return a transform
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);    
    }
}
