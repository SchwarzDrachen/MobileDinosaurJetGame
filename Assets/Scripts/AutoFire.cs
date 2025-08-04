using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    [SerializeField] Rigidbody rockPrefab;
    [SerializeField] float shootingInterval = 1.0f;
    [SerializeField] private float travelSpeed = 5.0f;
    [SerializeField] private Transform[] shootingPoint;
    private float timer;

    void Start()
    {
        timer = shootingInterval;
        Physics.IgnoreCollision(rockPrefab.GetComponent<Collider>(), GetComponent<Collider>());
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
        if (shootingPoint.Length > 0)
        {
            Rigidbody rockClone = Instantiate(rockPrefab, shootingPoint[0].position, shootingPoint[0].rotation);
            rockClone.velocity = transform.up * travelSpeed;
        }
        else
        {
            for (int i = 0; i <= shootingPoint.Length; i++)
            {
                Rigidbody rockClone = Instantiate(rockPrefab, shootingPoint[i].position, shootingPoint[i].rotation);
                rockClone.velocity = transform.up * travelSpeed;
            }
        }
    }
}
