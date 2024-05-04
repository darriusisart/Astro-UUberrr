using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToMain : MonoBehaviour
{
    public float switchSceneTime = 5.0f; // Time in seconds before switching to the next scene
    void Start()
    {
        // Start the timer for switching scene
        Invoke("SwitchScene", switchSceneTime);
    }

    void SwitchScene()
    {
        // Load the next scene
        SceneManager.LoadScene("MainMenu");
    }
}
