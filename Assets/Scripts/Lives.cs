using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] public int currentHealth = 3;
    [SerializeField] public int maxHealth = 3;

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        {
            --currentHealth;
        }
    }
}
