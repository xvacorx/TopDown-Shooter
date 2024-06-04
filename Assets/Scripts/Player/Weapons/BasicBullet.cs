using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet
{
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}