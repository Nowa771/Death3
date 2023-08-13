using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerRight : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the platform moves
    public float moveDistance = 5f; // Total distance the platform moves up and down

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the platform towards the target position smoothly
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the platform has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
            {
                isMoving = false;
            }
        }
    }

    public void TogglePlatform()
    {
        // Toggle the platform between the initial position and the raised position
        targetPosition = targetPosition == initialPosition ? initialPosition + Vector3.right * moveDistance : initialPosition;
        isMoving = true;
    }

    public void LowerPlatform()
    {
        // Lower the platform to its initial position
        targetPosition = initialPosition;
        isMoving = true;
    }
}