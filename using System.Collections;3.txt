using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private bool canJump = true; // New flag to control jumping

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && !canJump)
        {
            canJump = true; // Reset the jump flag when grounded
        }

        // Handle movement
        float moveDirection = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveDirection, 0, 0);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, rb.velocity.z);

        // Handle jumping
        if (canJump && isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            canJump = false; // Prevent further jumps until grounded again
        }
    }
}