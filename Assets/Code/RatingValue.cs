using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingValue : MonoBehaviour
{
    public TextMesh numberText; // Reference to the TextMesh component
    public float delay = 1f; // Delay before displaying the random number

    void Start()
    {
        // Start the coroutine to display the random number after the delay
        StartCoroutine(DisplayRandomNumberAfterDelay());
    }

    IEnumerator DisplayRandomNumberAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Generate a random number between 1 and 5 
        float randomNumber = Random.Range(3, 6);

        // Set the text of the TextMesh component to display the random number
        numberText.text = "** " + randomNumber + " **";
    }
}
