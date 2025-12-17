using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public levelManager LevelManager;
    public List<WaveData> WaveDatas = new List<WaveData>();
    public float waveWaitTime = 10;
    float waveWaitTimer = 0;
    bool isSpawning = false;
    bool isWaitingNextWave = true;
    int enemiesWaveSpawned = 0;

    int currentWaveIndex = 0;
    List<BaseEnemy> Spawnedaenemies = new List<BaseEnemy>();
    float SpawnRateTime = 10f;
    float SpawnRateTimer;

    public void Update()
    {
        if (isWaitingNextWave)
        {
            waveWaitTimer += Time.deltaTime;
            if (waveWaitTimer > waveWaitTime)
            {
                isWaitingNextWave = false;
                isSpawning = true;
                StartWave();
            }
        }

        if (isSpawning)
        {
           SpawnRateTimer += Time.deltaTime;
            if (SpawnRateTimer > SpawnRateTime)
            {
               SpawnRateTimer = 0;
               BaseEnemy enemyToSpawn = WaveDatas[currentWaveIndex].GetRandomEnemy();
               BaseEnemy newEnemy = Instantiate(enemyToSpawn, LevelManager.pathPoints[0].position, Quaternion.identity);
                Spawnedaenemies.Add(newEnemy);
                enemiesWaveSpawned++;   
               if (enemiesWaveSpawned >= WaveDatas[currentWaveIndex].enemiesAmount)
                {
                    isSpawning= false;
                }
            }
        }
    }

    void StartWave()
    {
      
        SpawnRateTime =  WaveDatas[currentWaveIndex].GetSpawnRateTime();
        SpawnRateTimer = 0;
    }




}
