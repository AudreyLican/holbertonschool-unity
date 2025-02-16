using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;
    public bool isGrounded;

    private Rigidbody rb;
    private Vector3 startPosition; //store the start position player
    private float fallThreshold = -10f; // Y-coordinate below which the player resets

    // Refer to Timer script
    private Timer timer;
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
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0.0f, z) * speed;
        rb.MovePosition(transform.position + move * Time.deltaTime); //make test self or world

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Set isGrounded to false after jumping
        }

        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            ResetPlayer();
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
        if (other.gameObject.CompareTag("Ground"))
        {
            // Reset isGrounded when player touches the ground
            isGrounded = true;
        }
    }
}

