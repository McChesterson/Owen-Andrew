using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    
    void Update()
    {
        //getting the input from w,a,s,d and arrows
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //setting what animation to use
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //flipping animation when walking to the left
        if (movement.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (movement.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //code accually moving the Player
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
