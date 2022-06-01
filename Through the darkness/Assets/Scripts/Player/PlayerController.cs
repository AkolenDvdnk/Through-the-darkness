using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTimerSet;
    [SerializeField] float dashForce;

    [Header("Unity Setup Fields")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Animator animator;

    private float movementInputDirection;
    private float groundCheckRadius = 0.1f;
    private float jumpTimer;

    private bool isGrounded;
    private bool isAttemptingToJump;

    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckInput();
        CheckJump();
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
            else
            {
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }
    private void Dash()
    {
        animator.SetTrigger("dash");
        rb.AddForce(Vector2.right * dashForce, ForceMode2D.Force);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void CheckJump()
    {
        if (jumpTimer > 0 && isGrounded)
        {
            Jump();
        }
        if (isAttemptingToJump)
        {
            jumpTimer -= Time.deltaTime;
        }
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
