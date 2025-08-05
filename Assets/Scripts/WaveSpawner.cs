using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject enemyPrefabBoss;
    private int enemyCount;
    [SerializeField] private int waveNumber;
    [SerializeField] float timeBetweenEnemySpawn;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform bossSpawnPoint;
    bool spawnWave;


    void Start()
    {
        StartCoroutine(SpawnWave(waveNumber));
        Debug.Log("Wave Starting");
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !spawnWave)
        {
            Debug.Log("New Wave");
            waveNumber++;
            StartCoroutine(SpawnWave(waveNumber));
        }
        else if (waveNumber > 6)
        {
            StopCoroutine(SpawnWave(waveNumber));
        }
    }

    IEnumerator SpawnWave(int enemiesToSpawn) {
        Debug.Log("Spawning Wave");
        spawnWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        if (enemiesToSpawn != 6)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Debug.Log("Enemy Spawning");
                enemyPrefabs[i] = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyPrefabs[i], spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefabs[i].transform.rotation);
                yield return new WaitForSeconds(timeBetweenEnemySpawn);
            }
        }
        else
        {
            Instantiate(enemyPrefabBoss, bossSpawnPoint.position, enemyPrefabBoss.transform.rotation);
        }
        spawnWave = false;
    }
}
