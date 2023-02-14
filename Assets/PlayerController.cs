using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed= 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    //private bool grounded;
    private Animator anim;

    //private enum MovementState {idle, run, jumping, falling}


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        //Set animator parameters
        anim.SetBool("run", horizontal != 0);
        anim.SetBool("grounded", IsGrounded());

        //UpdateAnimationState();

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        anim.SetTrigger("jump");

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

/*    private void Jump()
    {

    }*/

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public bool canAttack()
    {
        return horizontal == 0 && IsGrounded(); 
    }


/*    private void UpdateAnimationState()
    {
        MovementState state;


        if (horizontal > 0f)
        {
            state = MovementState.run;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

*//*        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }*//*

        anim.SetInteger("state", (int)state);
    }*/
}
