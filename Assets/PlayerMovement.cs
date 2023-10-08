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
    
    public Vector2 movement;
    public Vector2 playerDirection;

    public bool dash = false;
    public float dashLength = 0.3f;
    public float dashRemaining = 0f;
    public bool dashReady = true;


    private void Start()
    {
        moveSpeed = walkSpeed;
        dashRemaining = dashLength;
        playerDirection = new (0, -1);
    }

    void DashCooldown()
    {
        dashReady = true;
    }

    void Update()
    {
        //getting the input from w,a,s,d and arrows
        if (!dash)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
        }

        //checking if dash is possible and setting to dash speed
        if (Input.GetKeyDown(KeyCode.C) && dashReady == true)
        {
            dash = true;
            dashReady = false;
            moveSpeed = dashSpeed;
            Debug.Log("dashed");
            
        }
        //when the dash starts
        if (dash)
        {
            //if the dash in still going, lower the time left in the dash
            if (dashRemaining > 0)
            {
                dashRemaining -= Time.deltaTime;
            }
            //ending the dash and starting the DashCooldown
            else
            {
                dash = false;
                moveSpeed = walkSpeed;
                dashRemaining = dashLength;
                Invoke("DashCooldown", 2f);
            }
        }

        //setting the playerDirection variable to be equal to the last movement
        if (movement.x != 0f || movement.y != 0f)
        {
            playerDirection = movement;
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
