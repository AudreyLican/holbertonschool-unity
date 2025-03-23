using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<Timer>(out Timer playerTimer))
            {
                playerTimer.enabled = true; // Enable Timer script
                playerTimer.StartTimer(); // Start counting
            }

            Destroy(gameObject); // Remove trigger so it doesn't run again
        }
    }
}
