using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    public static PlayerComponents instance;

    protected Animator animator;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    protected virtual void Update()
    {
        CheckAbility();
        UpdateAnimation();
    }
    protected virtual void FixedUpdate() { }
    protected virtual void CheckAbility() 
    {
        CheckInput();
        UpdateAnimation();
    }
    protected virtual void CheckInput() { }
    protected virtual void UpdateAnimation() { }
}
