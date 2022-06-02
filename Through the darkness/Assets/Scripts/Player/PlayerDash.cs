using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerComponents
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;

    private float dashTimer;
    private bool isDashing;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;
    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("dash");
            Dash();
        }
    }
    protected override void CheckAbility()
    {
        base.CheckAbility();

        if (isDashing)
        {
            if(dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                rb.MovePosition(newPosition);
                dashTimer += Time.deltaTime;
            }
            else
            {
                PlayerController.instance.canMove = true;
                isDashing = false;
            }
        }
    }
    private void Dash()
    {
        isDashing = true;
        dashTimer = 0f;
        PlayerController.instance.canMove = false;
        dashOrigin = transform.position;

        dashDestination = transform.position + (Vector3)PlayerController.instance.LookDirection() * dashDistance;
    }
}
