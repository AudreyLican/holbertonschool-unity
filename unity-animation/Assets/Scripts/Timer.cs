using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // display  timer
    private float elapsedTime = 0f;
    private bool isRunning = false;

    public Text finalTimeText; // Reference to the FinalTime text on WinCanvas

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
        
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        timerText.text = $"{minutes:0}:{seconds:00}.{milliseconds:00}";
    }

    // Method to be called when player touches the flag (trigger win)
    public void Win()
    {
        // Display the final time in the FinalTime UI text on the WinCanvas
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        finalTimeText.text = $"Final Time: {minutes:0}:{seconds:00}.{milliseconds:00}";

        // Optionally, stop the timer here
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }
}
