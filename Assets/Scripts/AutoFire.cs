using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    [SerializeField] Rigidbody rockPrefab;
    [SerializeField] float shootingInterval = 1.0f;
    [SerializeField] private float travelSpeed = 5.0f;
    public Transform shootingPoint;
    private float timer;

    void Start()
    {
        timer = shootingInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Shoot();
            timer = shootingInterval;
        }
    }

    private void Shoot()
    {
        Rigidbody rockClone = Instantiate(rockPrefab, shootingPoint.position, shootingPoint.rotation);
        rockClone.velocity = transform.up * travelSpeed;
    }
}
