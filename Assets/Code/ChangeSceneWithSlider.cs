using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneWithSlider : MonoBehaviour
{
    public Slider slider; // Reference to the Slider UI component
    public int[] sceneIDs;
    void Start()
    {
        // Subscribe to the onValueChanged event of the slider
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        // Check if the slider value becomes 0
        if (value == 0f)
        {
            if (sceneIDs.Length > 0)
            {
                // Choose a random scene from the array
                int randomIndex = Random.Range(0, sceneIDs.Length);
                int randomSceneID = sceneIDs[randomIndex];

                // Load the randomly selected scene
                SceneManager.LoadScene(randomSceneID);
            }
        }
    }
}