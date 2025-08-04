using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject enemyPrefabBoss;
    private int enemyCount;
    [SerializeField]  public int waveNumber;
    [SerializeField] float timeBetweenEnemySpawn;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform bossSpawnPoint;
    public bool spawnWave;
    void Start()
    {
        StopCoroutine(SpawnWave(waveNumber));
        StartCoroutine(SpawnWave(waveNumber));
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !spawnWave)
        {
            StopCoroutine(SpawnWave(waveNumber));
            waveNumber++;
            StartCoroutine(SpawnWave(waveNumber));
        }
        else if (waveNumber > 6)
        {
            StopCoroutine(SpawnWave(waveNumber));
        }
    }

    IEnumerator SpawnWave(int enemiesToSpawn) {
        GameObject enemyToSpawn;
        spawnWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        if (enemiesToSpawn != 6)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyToSpawn.transform.rotation);
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
