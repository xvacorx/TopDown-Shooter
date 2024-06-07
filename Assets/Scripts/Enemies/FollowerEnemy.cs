using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : Enemy
{
    private Animator anim;
    private Transform player;
    public float speed = 2.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player != null && alive)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(player);
            anim.SetBool("isMoving", true);
        }
        else { anim.SetBool("isMoving", false); }
    }
    public override void Die()
    {
        anim.SetTrigger("death");
    }
}
