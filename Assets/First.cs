using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{

    private bool facingRight = true;

    private float move = 0;

    Animator m_Animator;

    SpriteRenderer m_SpriteRenderer;

    private void Flip()
    {
        facingRight = !facingRight;

        this.m_SpriteRenderer.flipX = !facingRight;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move == 0)
        {
            m_Animator.SetBool("isStay", true);
        }
        else
        {
            m_Animator.SetBool("isStay", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                this.Flip();
            }
            transform.Translate(new Vector3(5f * Time.deltaTime, 0f), 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                this.Flip();
            }
            transform.Translate(new Vector3(-5f * Time.deltaTime, 0f), 0);
        }
    }
}
