using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f; // Ensure game starts unpaused
        pauseMenu.SetActive(false); // Hide pause menu at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true); // Display the pause menu
        Time.timeScale = 0f; // Pause game time
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reset time scale before loading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads current level
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }
}
