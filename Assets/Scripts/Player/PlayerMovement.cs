using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (transform.position.y < 1)
        {
            Vector3 correctedPosition = transform.position;
            correctedPosition.y = 1;
            transform.position = correctedPosition;
        }
    }
}
