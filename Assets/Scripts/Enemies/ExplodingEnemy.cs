using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    private Transform player;
    private Animator anim;
    public float explosionRadius = 5f;
    public float explosionDamage = 15f;
    public GameObject explosionEffect;
    private bool isExploding = false;
    GameObject explode;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (player != null && alive)
        {
            Vector3 lookPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookPosition);
        }
    }

    public override void Die()
    {
        anim.SetTrigger("death");
        if (!isExploding)
        {
            isExploding = true;
            StartCoroutine(ExplodeAfterDelay(1.3f));
        }
    }

    private IEnumerator ExplodeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (explosionEffect != null)
        {
            explode = Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            PlayerManager targetHealth = hitCollider.GetComponent<PlayerManager>();
            if (targetHealth != null)
            {
                targetHealth.LoseHealth(explosionDamage);
            }
            Enemy enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null && enemy != this)
            {
                enemy.TakeDamage(explosionDamage);
            }
        }
        Destroy(explode, 2f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}