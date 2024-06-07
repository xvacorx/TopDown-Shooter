using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float damage;
    public float hp;
    public bool alive = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (alive && collision.gameObject.TryGetComponent(out PlayerManager objective))
        {
            objective.LoseHealth(damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") && PlayerManager.Instance != null  && alive)
        {
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