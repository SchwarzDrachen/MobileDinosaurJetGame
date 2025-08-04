using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] GameObject livesManager;
    void Start()
    {
        livesManager = GameObject.Find("LivesManager");
        livesManager.GetComponent<LivesManager>().bossDied = false;
    }

    void Update()
    {
        if (gameObject.GetComponent<Lives>().currentHealth == 0)
        {
            livesManager.GetComponent<LivesManager>().bossDied = true;
        }
    }
}
