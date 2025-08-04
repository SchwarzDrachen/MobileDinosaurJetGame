using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameSection;
    [SerializeField] GameObject storySection;
    [SerializeField] GameObject winSection;
    [SerializeField] GameObject lostSection;
    [SerializeField] GameObject player;
    [SerializeField] GameObject waveSpawnerManager;
    [SerializeField] GameObject livesManager;

    public void StartGame()
    {
        gameSection.SetActive(true);
        storySection.SetActive(false);
    }

    public void RestartGameWon()
    {
        gameSection.SetActive(true);
        winSection.SetActive(false);
        player.GetComponent<Lives>().currentHealth = player.GetComponent<Lives>().maxHealth;
        waveSpawnerManager.GetComponent<WaveSpawner>().waveNumber = 0;
        waveSpawnerManager.GetComponent<WaveSpawner>().spawnWave = false;
        livesManager.GetComponent<LivesManager>().bossDied = false;
    }
    public void RestartGameLost()
    {
        gameSection.SetActive(true);
        lostSection.SetActive(false);
        player.GetComponent<Lives>().currentHealth = player.GetComponent<Lives>().maxHealth;
        waveSpawnerManager.GetComponent<WaveSpawner>().waveNumber = 0;
        waveSpawnerManager.GetComponent<WaveSpawner>().spawnWave = false;
        livesManager.GetComponent<LivesManager>().bossDied = false;
    }
}
