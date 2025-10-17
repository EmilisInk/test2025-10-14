using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 2.5f;
    private Rigidbody2D rb;
    public bool isGrounded = true;
    private Animator anim;
    public AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;

            if (anim != null)
            {
                anim.SetTrigger("Jump");
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        if (anim != null)
        {
            anim.SetBool("isFalling", rb.velocity.y < 0 && !isGrounded);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y == -1 || direction.x == 1 || direction.x == -1) /// 1  right /// -1 left /// y 1 up /// y -1 down
            {
                isGrounded = false;
            }

            if (anim != null)
            {
                anim.SetBool("isFalling", false);
            }
        }
        if(collision.collider.CompareTag("Ladder"))
        {

        }
    }
}
