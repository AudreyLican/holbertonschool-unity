using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    // Go to the MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change this to your Main Menu scene name
    }

    // Method to load the next level
    public void Next()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there's a next level in the build settings
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // If this is the last level, go to Main Menu
            SceneManager.LoadScene("MainMenu"); // Change this to your Main Menu scene name
        }
    }
}
