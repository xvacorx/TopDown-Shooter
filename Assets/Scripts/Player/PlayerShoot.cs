using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;
    [SerializeField] Transform projectileParent;

    public bool shootingEnabled = true;

    private PlayerManager playerManager;
    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>(true);
        playerManager = GetComponent<PlayerManager>();
        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            if (playerManager.playerAlive)
            {
                Shoot();
            }
            yield return new WaitForSeconds(playerManager.attackSpeed);
        }
    }

    void Shoot()
    {
        GameObject instantiatedProjectile = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        instantiatedProjectile.transform.SetParent(projectileParent);
        playerAnimator.SetTrigger("shoot");
    }
}