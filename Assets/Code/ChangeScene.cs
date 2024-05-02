using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Slider slider;
    public string sceneToLoad; // Name of the scene to load when the slider reaches its max value

    void Update()
    {
        // Check if the slider value reaches its maximum value (1.0f)
        if (slider.value >= 1.0f)
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
