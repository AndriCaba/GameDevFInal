using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class HealthScriptPlayer : MonoBehaviour
{
    
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    public GameObject 
    PlayerObject, 
    Health_UI,
    Death_UI;
    

    [Header("UI")]
    [SerializeField] private Slider healthBar; // Reference to the Health Bar UI Slider

    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        Health_UI = GameObject.Find("Healthbar UI");
        Death_UI = GameObject.Find("DeathUI");
        Death_UI.SetActive(false);
        
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // Set the max value of the slider
            healthBar.value = currentHealth; // Set the initial value
        }
        else if (PlayerObject == null) { Debug.Log("Object notfound");}
    }
    void Update(){

        if(Input.GetKey(KeyCode.K)){ TakeDamage(3);}
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        UpdateHealthBar();

        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        UpdateHealthBar();

        Debug.Log($"Player healed {amount}. Current health: {currentHealth}");
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth; // Update the slider to reflect current health
        }
    }

    private void Die()
    {
        Death_UI.SetActive(true);
        PlayerObject.SetActive(false);
        Health_UI.SetActive(false);
        
        
        Debug.Log("Player has died!");
        // Add logic for player death, e.g., restarting the level, playing an animation, etc.
    }
}

