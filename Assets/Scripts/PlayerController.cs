using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public LayerMask cannonLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    public bool isGrounded;
    private float groundCheckRadius = 0.1f;

    public bool launched;

    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, cannonLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        if(rb.velocity.y != 0)
        {
            animator.SetBool("isJumping", true);
        }

        if(rb.velocity.x > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.velocity.x < 0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void BeginLaunch()
    {
        StartCoroutine(LaunchPlayer());
    }

    public IEnumerator LaunchPlayer()
    {
        rb.velocity = new Vector2(rb.velocity.x, 20f);

        if (!launched)
        {
            launched = true;
            yield return new WaitForSeconds(0.2f);
            launched = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("die");
        }
    }
}
