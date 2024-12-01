    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject door; // Reference to the door GameObject
    public Sprite leverOnSprite; // Sprite for the lever in the "on" position
    public Sprite leverOffSprite; // Sprite for the lever in the "off" position
    public bool isDoorOpen = false; // Initial state of the door

    private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false; // Checks if the player is near the lever

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLeverSprite();
    }

    void Update()
    {
        // Check if the player is in range and presses the interact key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        isDoorOpen = !isDoorOpen;

        // Update the door's state (e.g., enable/disable or animate)
        if (isDoorOpen)
        {
            door.SetActive(false); // Hide or disable the door
        }
        else
        {
            door.SetActive(true); // Show or enable the door
        }

        UpdateLeverSprite();
    }

    private void UpdateLeverSprite()
    {
        // Change the lever's sprite based on its state
        spriteRenderer.sprite = isDoorOpen ? leverOnSprite : leverOffSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
