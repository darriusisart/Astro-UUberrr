using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButtonToStart : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    void Update()
    {
        // Check if any button is pressed
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) &&
            !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow) &&
            !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) &&
            !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) &&
            !Input.GetKeyDown(KeyCode.Space))
        {
            // Load the next scene
            SceneManager.LoadScene("mainMenu");
        }
    }
}
