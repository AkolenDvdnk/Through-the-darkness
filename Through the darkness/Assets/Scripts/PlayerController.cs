using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;

    [Header("Unity Setup Fields")]
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Animator animator;

    private float movementInputDirection;
    private float groundCheckRadius = 0.1f;

    private bool isGrounded;

    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckInput();
        UpdateAnimation();
        Flip();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckGround();
    }
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
    }
    private void UpdateAnimation()
    {
        animator.SetFloat("moveSpeed", Mathf.Abs(movementInputDirection));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    private void Flip()
    {
        if (movementInputDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementInputDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
