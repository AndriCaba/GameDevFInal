using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 public Transform target; // The object the camera follows
    public float smoothSpeed = 0.125f; // Smoothness factor
    public Vector3 offset; // Offset from the target
    public Vector2 minBounds; // Minimum bounds of the camera (screen edges)
    public Vector2 maxBounds; // Maximum bounds of the camera

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position with offset, but only considering x and y for 2D
        Vector3 desiredPosition = target.position + offset;

        // Clamp the camera position to ensure it doesn't go out of bounds
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // Smoothly interpolate the camera's position towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
