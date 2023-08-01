using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Transform firePoint;  
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("Shoot", 1f, 1f); 
    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  // (generate bullet, position, rotation)
    }
}
