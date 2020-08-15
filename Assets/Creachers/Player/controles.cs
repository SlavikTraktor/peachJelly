using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    public float horizontalSpeed = 0.2f;
    float speedX;
    public float verticalSpeed = 0.1f;
    float speedY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
        }
            transform.Translate(speedX, 0, 0);
        speedX = 0;
        if (Input.GetKey(KeyCode.S))
        {
            speedY = -verticalSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            speedY = verticalSpeed;
        }

        transform.Translate(0, speedY, 0);
        speedY = 0;
    }
}
