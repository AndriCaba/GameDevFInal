using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowdartObject : MonoBehaviour
{
    public enum FireDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    [Header("Dart Settings")]
    [SerializeField] private GameObject dartPrefab; // Dart prefab to fire
    [SerializeField] private Transform firePoint; // Position to fire from
    [SerializeField] private float fireRate = 1f; // Time between shots (seconds)
    [SerializeField] private float dartSpeed = 10f; // Speed of the dart
    [SerializeField] private FireDirection fireDirection = FireDirection.Right; // Direction to fire

    private float nextFireTime = 0f;

    void Update()
    {
        // Automatically fire darts at intervals
        if (Time.time >= nextFireTime)
        {
            FireDart();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireDart()
    {
        if (dartPrefab != null && firePoint != null)
        {
            // Instantiate the dart
            GameObject dart = Instantiate(dartPrefab, firePoint.position, Quaternion.identity);

            // Get the normalized firing vector based on the enum
            Vector2 direction = GetFireDirectionVector();

            // Apply velocity to the dart
            Rigidbody2D rb = dart.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * dartSpeed; // Apply direction and speed
            }

            Debug.Log($"Dart fired in direction: {direction}");
        }
        else
        {
            Debug.LogWarning("Dart prefab or fire point is missing!");
        }
    }

    private Vector2 GetFireDirectionVector()
    {
        switch (fireDirection)
        {
            case FireDirection.Right:
                return Vector2.right;
            case FireDirection.Left:
                return Vector2.left;
            case FireDirection.Up:
                return Vector2.up;
            case FireDirection.Down:
                return Vector2.down;
            default:
                return Vector2.right;
        }
    }
}
