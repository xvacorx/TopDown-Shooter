using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") && PlayerManager.Instance != null)
        {
            float playerDamage = PlayerManager.Instance.damage;
            TakeDamage(playerDamage);
        }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}