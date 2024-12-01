using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
  [Header("Lava Settings")]
    [SerializeField] private int damagePerSecond = 9000; // Damage dealt to the player every second
    
    private bool isPlayerInLava = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the lava zone
        if (other.CompareTag("Player"))
        {
            isPlayerInLava = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the lava zone
        if (other.CompareTag("Player"))
        {
            isPlayerInLava = false;
        }
    }

    private void Update()
    {
        // Deal damage to the player continuously while in lava
        if (isPlayerInLava)
        {
            DealDamageToPlayer();
        }
    }

    private void DealDamageToPlayer()
    {
        // Find the player object and deal damage
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            HealthScriptPlayer playerHealth = player.GetComponent<HealthScriptPlayer>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerSecond ); // Apply damage per frame
                Debug.Log($"Player is in lava and took {damagePerSecond } damage.");
            }
        }
    }
}
