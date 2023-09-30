using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed;
    public float walkSpeed = 5f;
    public float dashSpeed = 10f;
    Vector2 movement;

    public bool dash = false;
    public float dashLength = 3f;
    public float dashRemaining;
    
    void Update()
    {
        //getting the input from w,a,s,d and arrows
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        //dashing
        if (Input.GetKeyDown(KeyCode.C))
        {
            dash = true;
            dashRemaining = dashLength;
            moveSpeed = dashSpeed;
            Debug.Log("dashed");
            
        }
        else
        {
            if (dashRemaining > 0)
            {
                dashRemaining -= 0.5f * Time.fixedDeltaTime;
            }
            else
            {
                dash = false;
                moveSpeed = walkSpeed;
            }
            
        }

        //setting what animation to use
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("isDashing", dash);
        


        //flipping animation when walking to the left
        if (movement.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (movement.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void FixedUpdate()
    {
        //code moving the Player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
