using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCamera : MonoBehaviour
{
    Camera m_Camera;

    public float moveSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        this.m_Camera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0f), 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime), 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0f, -moveSpeed * Time.deltaTime), 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f), 0);
        }
    }
}
