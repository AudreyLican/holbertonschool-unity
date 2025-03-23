using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas; // Reference to the WinCanvas
    public Timer timer; // Reference to the Timer script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate WinCanvas
            winCanvas.SetActive(true);

            // Call the Win method in Timer to display the final time
            timer.Win();
        }
    }
}
