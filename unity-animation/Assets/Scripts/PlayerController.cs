using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 7f;
    public bool isGrounded;

    private Rigidbody rb;
    private Vector3 startPosition; //store the start position player
    private float fallThreshold = -10f; // Y-coordinate below which the player resets

    private Timer timer; // Refer to Timer script

    private Animator animator; // Animator ref to control animations

    // For running detection
    private float speedThreshold = 0.1f; // speed to consider as running

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Store the initial position

        // Get the Timer component
        timer = GetComponent<Timer>();

        // Ensure timer is disabled at start
        if (timer != null)
        {
            timer.enabled = false; // Timer will start when leaving TimerTrigger
        }

        // Get the Animator component
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        /// Calculate movement vector
        Vector3 move = new Vector3(x, 0.0f, z) * speed;

        // Move the player
        rb.MovePosition(transform.position + move * Time.deltaTime);

        // Update animations based on movement
        UpdateAnimations(move.magnitude);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Falling detection: Only set falling if not grounded
        if (!isGrounded && rb.velocity.y < -1f)
        {
            animator.SetBool("isFalling", true);
        }

        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            ResetPlayer();
        }
    }


    // Update animations based on movement and jumping
    private void UpdateAnimations(float moveMagnitude)
    {
        if (animator == null) return; // Prevent NullReferenceException

        // Running animation
        animator.SetBool("isRunning", moveMagnitude > speedThreshold);

        // Handle falling transition correctly
        if (!isGrounded)
        {
            animator.SetBool("isFalling", rb.velocity.y < -1f);
        }
        else
        {
            animator.SetBool("isFalling", false); // Stop falling when on the ground
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;

        if (animator != null)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("isFalling", false); // Prevent immediate falling animation
        }
    }


    // Reset Player to start position
    private void ResetPlayer()
    {
        rb.velocity = Vector3.zero; // Reset velocity to avoid carrying momentum
        transform.position = startPosition + new Vector3(0, 10f, 0); // Respawn player slightly above
    }


    // check if player is landed
    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;

        if (animator != null)
        {
            animator.SetBool("isFalling", false); // Stop falling animation

            // If player was falling, trigger impact animation
            if (rb.velocity.y < -5f)
            {
                animator.SetTrigger("FallingFlatImpact");
            }
        }
    }
}

