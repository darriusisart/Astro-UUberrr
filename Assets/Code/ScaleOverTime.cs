using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleOverTime : MonoBehaviour
{
    public float scaleFactor = 0.1f; // Amount to scale by per second
    public float maxScale = 2.0f; // Maximum scale for x and y axes
    public float switchSceneTime = 5.0f; // Time in seconds before switching to the next scene
    private Vector3 initialScale; // Initial scale of the object

    void Start()
    {
        // Store the initial scale of the object
        initialScale = transform.localScale;

        // Start the timer for switching scene
        Invoke("SwitchScene", switchSceneTime);
    }

    void Update()
    {
        // Calculate the new scale
        float newScaleX = transform.localScale.x + scaleFactor * Time.deltaTime;
        float newScaleY = transform.localScale.y + scaleFactor * Time.deltaTime;

        // Clamp the scale to the maximum value
        newScaleX = Mathf.Clamp(newScaleX, initialScale.x, maxScale);
        newScaleY = Mathf.Clamp(newScaleY, initialScale.y, maxScale);

        // Apply the new scale to the object
        transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);
    }

    void SwitchScene()
    {
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
