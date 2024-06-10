using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject hitEffect;
    GameObject hit;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hit, 0.5f);
            Destroy(gameObject);
        }
    }
}
