using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;

    public bool shootingEnabled = true;
    void Start()
    {
        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
    {
        while (true)

        {
            if (shootingEnabled)
            {
                Shoot();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    void Shoot()
    {
        Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
    }
}