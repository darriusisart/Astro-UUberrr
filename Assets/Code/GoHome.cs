using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
    // Method that will be invoked by the button
    public void ReturnToIntro()
    {
        // Replace "IntroScene" with the actual name of your intro scene
        SceneManager.LoadScene("Intro");
    }
}
