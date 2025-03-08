using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        // Save the current scene name before opening options
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Application.Quit(); //Quit Game
    }
}
