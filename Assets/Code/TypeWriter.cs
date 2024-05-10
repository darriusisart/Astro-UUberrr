using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{ 
    public TextMesh textMesh;
    public float initialDelay = 1.0f; // Initial delay before typing starts
    public float letterDelay = 0.1f; // Delay between each letter appearing
    public float blinkDuration = 1.0f; // Duration of blinking animation
    public float blinkInterval = 1.0f; // Interval between blinks
    private string fullText;
    private float timeSinceLastLetter;
    private bool isBlinking = false;
    private bool isTyping = false;

    void Start()
    {
        fullText = textMesh.text;
        textMesh.text = ""; // Clear the text initially

        // Start typing after initialDelay
        Invoke("StartTyping", initialDelay);
    }

    void StartTyping()
    {
        isTyping = true;
    }

    void Update()
    {
        if (!isTyping) return;

        if (textMesh.text != fullText)
        {
            timeSinceLastLetter += Time.deltaTime;

            if (timeSinceLastLetter >= letterDelay)
            {
                // Add the next letter
                int nextLetterIndex = textMesh.text.Length;
                textMesh.text += fullText[nextLetterIndex];
                timeSinceLastLetter = 0f;

                // Check if all letters are typed
                if (textMesh.text == fullText)
                {
                    isBlinking = true;
                    InvokeRepeating("BlinkText", 0f, blinkInterval);
                }
            }
        }
    }

    void BlinkText()
    {
        // Toggle visibility of the text
        textMesh.gameObject.SetActive(!textMesh.gameObject.activeSelf);

        // Stop blinking after blinkDuration
        Invoke("StopBlinking", blinkDuration);
    }

    void StopBlinking()
    {
        isBlinking = false;
        CancelInvoke("BlinkText");
        textMesh.gameObject.SetActive(true); // Ensure text is visible after blinking
    }
}
