using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float speedX = 0, speedY = 0;

        if (Input.GetKey(KeyCode.A))
        {
            speedX = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speedY = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            speedY = moveSpeed;
        }

        if (speedX != 0 && speedY != 0)
        {
            float speedXY = Mathf.Sqrt(2) / 2 * moveSpeed;
            speedX = speedXY * ((speedX > 0)? 1: -1);
            speedY = speedXY * ((speedY > 0)? 1: -1);
        }

        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }
}
