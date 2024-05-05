using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyValue : MonoBehaviour
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

        // Generate a random number between 100 and 1000
        int randomNumber = Random.Range(100, 1001);

        // Set the text of the TextMesh component to display the random number
        numberText.text = "$$" + randomNumber;
    }
}
