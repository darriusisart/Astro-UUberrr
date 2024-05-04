using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaler : MonoBehaviour
{
    public GameObject objectToScale; // Reference to the object you want to scale
    public float moveSpeed = 1f; // Speed at which the object moves up
    public float scaleSpeed = 1f; // Speed at which the object scales down
    public float delayTime = 3f; // Delay before scaling down begins

    private float startTime; // Time when the scaling started

    void Start()
    {
        startTime = Time.time; // Record the start time
    }

    void Update()
    {
        // Move the object up over time
        objectToScale.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Check if the delay time has passed
        if (Time.time - startTime >= delayTime)
        {
            // Calculate the scale factor based on the time elapsed since scaling started
            float scaleFactor = 1f - (scaleSpeed * (Time.time - startTime - delayTime));

            // Ensure scale factor doesn't go below 0
            if (scaleFactor < 0f)
            {
                scaleFactor = 0f;
            }

            // Apply the scale factor to the object's local scale
            objectToScale.transform.localScale = new Vector3(1f, scaleFactor, 1f);
        }
    }
}
