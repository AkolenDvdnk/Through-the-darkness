using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerComponents
{
    [Header("Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTimerSet;

    [Header("Unity Setup Fields")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask whatIsGround;

    private float movementInputDirection;
    private float groundCheckRadius = 0.1f;
    private float jumpTimer;

    private bool isGrounded;
    private bool isAttemptingToJump;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        CheckGround();
    }
    protected override void CheckInput()
    {
        base.CheckInput();

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
        base.CheckAbility();

        CheckJump();
        ApplyMovement();
        Flip();
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
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
        }
        else if (movementInputDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    protected override void UpdateAnimation()
    {
        base.UpdateAnimation();

        animator.SetFloat("moveSpeed", Mathf.Abs(movementInputDirection));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
