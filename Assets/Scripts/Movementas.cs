using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movementas : MonoBehaviour
{
    private Vector2 direction;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.mass = 20f;

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (anim != null)
        {
            anim.SetBool("isWalking", horizontal != 0);
        }

        if (spriteRenderer != null && horizontal != 0)
        {
            spriteRenderer.flipX = horizontal < 0;
        }

        if (audioSource != null)
        {
            if (Mathf.Abs(horizontal) > 0.1)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}



