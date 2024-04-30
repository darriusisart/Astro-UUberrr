using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceAway : MonoBehaviour
{
    public float startNumberMin = 0f; // Minimum start number
    public float startNumberMax = 100f; // Maximum start number
    public float decreaseSpeed = 1f; // Speed at which the number decreases
    public Slider slider; // Slider to update
    public TextMesh textMesh; // TextMesh to display the decreasing number
    private float currentNumber; // Current number value

    void Start()
    {
        // Generate a random start number within the specified range
        currentNumber = Random.Range(startNumberMin, startNumberMax);
    }

    void Update()
    {
        // Decrease the current number by the decreaseSpeed
        currentNumber -= decreaseSpeed * Time.deltaTime;

        // Ensure the current number doesn't go below zero
        currentNumber = Mathf.Max(currentNumber, 0f);

        // Update the slider value based on the current number
        if (slider != null)
        {
            slider.value = currentNumber / startNumberMax; // Normalize the value
        }

        // Update the TextMesh to display the current number
        if (textMesh != null)
        {
            textMesh.text = currentNumber.ToString("F1"); // Display one decimal place
        }
    }
}
