using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float i = 0; // The current rotation angle
    float x = 0; // The current position offset
    float direction = 1; // The current direction of movement (1 for up, -1 for down)
    Vector3 startPosition; // The starting position of the gameobject
    Quaternion startRotation; // The starting rotation of the gameobject

    void Start()
    {
        startPosition = transform.position; // Store the starting position of the gameobject
        startRotation = transform.rotation; // Store the starting rotation of the gameobject
    }

    void Update()
    {
        i += 0.01f * Time.deltaTime; // Increment the rotation angle
        if (i >= 360f) { // If the rotation angle reaches 360 degrees
            i = 0; // Reset the rotation angle to 0
            transform.rotation = startRotation; // Reset the rotation of the gameobject to its starting rotation
        }
        // Smoothly tilts a transform towards a target rotation.
        Vector3 rotationToAdd = new Vector3(0, i, 0);
        transform.Rotate(rotationToAdd);

        if (direction == 1 && x >= 0.3f) { // If the gameobject is moving up and has reached its maximum height
            direction = -1; // Change the direction to down
        } else if (direction == -1 && x <= -0.3f) { // If the gameobject is moving down and has reached its minimum height
            direction = 1; // Change the direction to up
        }
        x += 0.001f * direction; // Increment the position offset based on the current direction
        transform.position = startPosition + new Vector3(0, x, 0); // Update the position of the gameobject based on the position offset
    }
}
