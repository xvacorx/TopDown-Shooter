using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;

    public bool shootingEnabled = true;

    PlayerManager playerManager;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
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
            yield return new WaitForSeconds(playerManager.attackSpeed);
        }
    }
    void Shoot()
    {
        Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
    }
}