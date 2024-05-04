using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleDownOverTime : MonoBehaviour
{
    public float scaleFactor = 0.1f; // Amount to scale by per second
    public float minScale = 2.0f; // Maximum scale for x and y axes
    public float switchSceneTime = 5.0f; // Time in seconds before switching to the next scene
    public float moveSpeed = 1.0f;
    private Vector3 initialScale; // Initial scale of the object
    private Vector3 initialPosition;
    void Start()
    {
        // Store the initial scale of the object
        initialScale = transform.localScale;
        initialPosition = transform.position;
        // Start the timer for switching scene
        Invoke("SwitchScene", switchSceneTime);
    }

    void Update()
    {
        // Calculate the new scale
        float newScaleX = transform.localScale.x + scaleFactor * Time.deltaTime;
        float newScaleY = transform.localScale.y + scaleFactor * Time.deltaTime;

        // Clamp the scale to the maximum value
        newScaleX = Mathf.Clamp(newScaleX, minScale, initialScale.x);
        newScaleY = Mathf.Clamp(newScaleY, minScale, initialScale.y);

        // Apply the new scale to the object
        transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    void SwitchScene()
    {
        // Load the next scene
        SceneManager.LoadScene("Score");
    }
}
