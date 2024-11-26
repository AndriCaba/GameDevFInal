using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
   [Header("Climbing Settings")]
    public float climbSpeed = 5f; // Speed of climbing
    public Transform topBoundary; // The top of the ladder
    public Transform bottomBoundary; // The bottom of the ladder

    private Rigidbody2D playerRb; // Reference to the player's Rigidbody2D
    private bool isClimbing = false; // Is the player currently climbing?

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
            playerRb = other.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                playerRb.gravityScale = 0; // Disable gravity while climbing
                playerRb.velocity = Vector2.zero; // Reset velocity to avoid unintended movement
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;

            if (playerRb != null)
            {
                playerRb.gravityScale = 1; // Re-enable gravity
            }
        }
    }

    void Update()
    {
        if (isClimbing && playerRb != null)
        {
            // Get vertical input
            float verticalInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow Keys

            // Calculate the new position
            float newY = Mathf.Clamp(
                playerRb.position.y + verticalInput * climbSpeed * Time.deltaTime,
                bottomBoundary.position.y,
                topBoundary.position.y
            );

            // Apply climbing movement
            playerRb.velocity = new Vector2(0, 0); // Stop horizontal movement
            playerRb.position = new Vector2(playerRb.position.x, newY);
        }
    }
}
