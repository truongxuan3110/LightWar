using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Projectile bullet;
    public Transform[] firePoints;
    public float shotPerSeconds;
    private float nextShotTime;
    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (nextShotTime <= Time.time)
        {
            foreach(Transform firePoint in firePoints)
            {
                Projectile _bulet = Instantiate(bullet,firePoint.position,firePoint.rotation);
            }
            nextShotTime = Time.time + (1/shotPerSeconds);
        }
    }
}
