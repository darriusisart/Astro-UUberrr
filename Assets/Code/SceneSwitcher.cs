using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Sprite newSprite; // The sprite you want to change to

    private Button button; // Reference to the button component

    private void Start()
    {
        // Get the button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener for when the button is clicked
        button.onClick.AddListener(ChangeSprite);
    }

    private void ChangeSprite()
    {
        // Get the Image component attached to the button
        Image buttonImage = GetComponent<Image>();

        // Change the sprite of the Image component to the new sprite
        if (buttonImage != null && newSprite != null)
        {
            buttonImage.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("Button Image component or new sprite is not set!");
        }
    }
}
