using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    private Animator anim;
    private Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float followDistance = 10f;
    public float stopDistance = 5f;
    public float moveSpeed = 1.5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        if (player != null && alive)
        {
            Vector3 lookPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookPosition);

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > followDistance)
            {
                MoveTowardsPlayer();
                anim.SetFloat("movement", 1f);
            }
            else if (distanceToPlayer < stopDistance)
            {
                MoveAwayFromPlayer();
                anim.SetFloat("movement", -1f);
            }
            else { anim.SetFloat("movement", 0); }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void MoveAwayFromPlayer()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private IEnumerator ShootRoutine()
    {
        while (alive)
        {
                yield return new WaitForSeconds(2.75f);
                anim.SetTrigger("shoot");
                yield return new WaitForSeconds(0.25f);
                Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    public override void Die()
    {
        alive = false;
        Destroy(gameObject, 2f);
        anim.SetTrigger("death");
    }
}