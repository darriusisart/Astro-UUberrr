using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOStore : MonoBehaviour
{
    // Reference to the player's UFO
    public GameObject playerUFO;

    // Function to handle UFO selection
    public void SelectUFO(GameObject selectedUFO)
    {
        // Disable the current UFO
        playerUFO.SetActive(false);
        
        // Enable the selected UFO
        playerUFO = selectedUFO;
        playerUFO.SetActive(true);
        
        // Update any other relevant player data (e.g., save the selection)
        SavePlayerUFOSelection(selectedUFO.name);
    }

    // Function to save player's UFO selection (e.g., to PlayerPrefs)
    private void SavePlayerUFOSelection(string ufoName)
    {
        PlayerPrefs.SetString("ActiveUFO", ufoName);
    }
}
