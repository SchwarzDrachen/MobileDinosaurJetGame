using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject wonSection;
    [SerializeField] public GameObject lostSection;
    [SerializeField] public GameObject gameSection;
    public bool bossDied;

    void Update()
    {
        if (player.GetComponent<Lives>().currentHealth == 0)
        {
            GameObject[] EnemiesToDestroy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var i in EnemiesToDestroy)
            {
                Destroy(i);
            }
            lostSection.SetActive(true);
            gameSection.SetActive(false);
        }
        else if (bossDied)
        {
            wonSection.SetActive(true);
            gameSection.SetActive(false);
        }
    }
}
