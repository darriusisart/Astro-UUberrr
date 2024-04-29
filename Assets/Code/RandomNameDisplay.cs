using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomNameDisplay : MonoBehaviour
{
    // Array of names
    public string[] names;

    // Reference to the Text component where the name will be displayed
    public Text nameText;

    void Start()
    {
        // Call the DisplayRandomName function when the script starts
        DisplayRandomName();
    }

    // Function to display a random name from the array
    void DisplayRandomName()
    {
        // Check if there are names in the array
        if (names.Length > 0)
        {
            // Generate a random index within the range of the array
            int randomIndex = Random.Range(0, names.Length);

            // Get the name at the random index
            string randomName = names[randomIndex];

            // Display the random name on the Text component
            nameText.text = randomName;
        }
        else
        {
            // If the array is empty, display a message indicating that there are no names
            nameText.text = "No names in the array";
        }
    }
}
