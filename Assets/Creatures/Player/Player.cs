using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bigDialog;
    public float moveSpeed = 8f;
    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;
    private bool facingRight = true;

    private Collider2D radiusNPC;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        this.MovePlayer();
        this.ChooseSide();
        this.UpdateAnimatorSide();
        this.TryOpenDialog();
    }

    // Боже, какие же костыли я тут пишу
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            radiusNPC = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            radiusNPC = null;
        }
    }

    // User functions
    private void MovePlayer()
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
            speedX = speedXY * ((speedX > 0) ? 1 : -1);
            speedY = speedXY * ((speedY > 0) ? 1 : -1);
        }

        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    private void ChooseSide()
    {
        if (Input.GetKey(KeyCode.A) && facingRight)
        {
            this.Flip();
        }
        else if (Input.GetKey(KeyCode.D) && !facingRight)
        {
            this.Flip();
        }
    }

    private void UpdateAnimatorSide()
    {
        bool isSideRun = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        m_Animator.SetBool("isSideRun", isSideRun);

        bool isBotRun = Input.GetKey(KeyCode.S);
        m_Animator.SetBool("isBotRun", isBotRun);

        bool isTopRun = Input.GetKey(KeyCode.W);
        m_Animator.SetBool("isTopRun", isTopRun);

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = this.transform.localScale;
        scale.x = scale.x * -1;

        transform.localScale = scale;
    }

    private void TryOpenDialog()
    {
        if (radiusNPC != null && Input.GetKey(KeyCode.E) && GameObject.FindWithTag("BigDialog") == null)
        {
            Instantiate(bigDialog);
        }
    }
}
