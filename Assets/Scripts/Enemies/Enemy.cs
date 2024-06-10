using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float damage;
    public float hp;
    public bool alive = true;
    public GameObject hitEffect;
    GameObject hit;
    private void OnCollisionEnter(Collision collision)
    {
        if (alive && collision.gameObject.TryGetComponent(out PlayerManager objective))
        {
            objective.LoseHealth(damage);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") && PlayerManager.Instance != null  && alive)
        {
            hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hit, 0.5f);
            Destroy(other.gameObject);
            float playerDamage = PlayerManager.Instance.damage;
            TakeDamage(playerDamage);
        }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            alive = false;
            Die();
        }
    }
    public abstract void Die();
}