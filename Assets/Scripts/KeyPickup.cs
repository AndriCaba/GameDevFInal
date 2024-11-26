using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
  public DoorController door; // Assign the door in the inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.PickUpKey(); // Notify the door that the key has been picked up
            Destroy(gameObject); // Destroy the key object
        }
    }
}
