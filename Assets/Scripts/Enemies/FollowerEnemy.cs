using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : Enemy
{
    private Transform player;
    public float speed = 2.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(player);
        }
    }
}
