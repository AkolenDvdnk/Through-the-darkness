using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerComponents
{
    public static PlayerController instance;

    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTimerSet;

    [Header("Unity Setup Fields")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask whatIsGround;

    private float groundCheckRadius = 0.1f;
    private float jumpTimer;

    private bool isGrounded;
    private bool isAttemptingToJump;
    private bool isFacingRight = true;

    public float movementInputDirection { get; set; }
    public bool canMove { get; set; }

    protected override void Awake()
    {
        base.Awake();

        instance = this;
    }
    private void Start()
    {
        canMove = true;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        ApplyMovement();
        CheckGround();
    }
    protected override void CheckInput()
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
    }
    protected override void CheckAbility()
    {
        CheckJump();
        Flip();
        UpdateAnimation();
    }
    private void ApplyMovement()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
        }
    }
    public Vector2 LookDirection()
    {
        float lookDirection = -1;
        if (isFacingRight)
            lookDirection = 1;
        else
            lookDirection = -1;

        return new Vector2(lookDirection, 0f);
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
    private void Flip()
    {
        if (movementInputDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }
        else if (movementInputDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
    }
    private void UpdateAnimation()
    {
        animator.SetFloat("moveSpeed", Mathf.Abs(movementInputDirection));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
} 