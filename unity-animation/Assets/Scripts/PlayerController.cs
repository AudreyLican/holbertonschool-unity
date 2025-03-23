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
    private float speedThreshold = 0.1f; // Threshold speed to consider as running

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Store the initial poisiton

        // Get the Timer component
        timer = GetComponent<Timer>();

        // Ensure timer is desabled at start
        if (timer != null)
        {
            timer.enabled = false; //Timer will start when leaving TimerTrigger
        }

        // Get the Animator component
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 move = new Vector3(x, 0.0f, z) * speed;

        // Move the player
        rb.MovePosition(transform.position + move * Time.deltaTime);

        // Update the running animation based on movement speed
        UpdateRunningAnimation(move.magnitude);


        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            /**
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Set isGrounded to false after jumping**/
        }


        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            ResetPlayer();
        }
    }


    // Update the running animation based on player movement speed
    private void UpdateRunningAnimation(float moveMagnitude)
    {
        // If the player is moving and exceeds the threshold speed, set IsRunning to true
        if (moveMagnitude > speedThreshold)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        animator.SetTrigger("Jump");
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
        if (other.gameObject.CompareTag("Ground"))
        {
            // Reset isGrounded when player touches the ground
            isGrounded = true;
        }
    }
}

