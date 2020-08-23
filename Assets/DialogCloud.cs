using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCloud : MonoBehaviour
{
    public Animator m_Animator;
    private void Start()
    {
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            m_Animator.SetTrigger("Trigger");

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            m_Animator.SetTrigger("Trigger");

        }
    }
}
