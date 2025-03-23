using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public Toggle invertYToggle; // Drag Invert Y-Axis Toggle here
    private bool isInverted;

    void Start()
    {
        // Load the saved value of InvertY from PlayerPrefs
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        invertYToggle.isOn = isInverted; // Set the toggle state based on saved value
    }

    // Called when the Apply button is clicked
    public void Apply()
    {
        // Save the current state of InvertYToggle to PlayerPrefs
        PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save(); // Make sure changes are saved

        // Apply the settings to the game (reversing mouse behavior)
        isInverted = invertYToggle.isOn;

        // Return to the previous scene
        LoadPreviousScene();
    }

    // Called when the Back button is clicked
    public void Back()
    {
        LoadPreviousScene();
    }

    // Helper method to load the previous scene
    private void LoadPreviousScene()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }
}
