using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera; // Assign the Main Camera
    public Camera cutsceneCamera; // Assign the CutsceneCamera
    public GameObject player; // Assign the Player GameObject
    public GameObject timerCanvas; // Assign the TimerCanvas
    public Animator cutsceneAnimator; // Assign CutsceneCamera Animator

    private PlayerController playerController; // Ref. to player movement script
    void Start()
    {
        // Disable Main Camera at start
        mainCamera.gameObject.SetActive(false);

        // Disable player movement
        playerController = player.GetComponent<PlayerController>();
        playerController.enabled = false;

        // Hide TimerCanvas at start
        timerCanvas.SetActive(false);

        // Play the cutscene animation
        cutsceneAnimator.Play("Intro01");

        // Start a coroutine to wait for the animation to finish
        StartCoroutine(WaitForCutsceneEnd());
    }

    private System.Collections.IEnumerator WaitForCutsceneEnd()
    {
        // Wait until the animation is finished
        yield return new WaitForSeconds(cutsceneAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Enable Main Camera
        mainCamera.gameObject.SetActive(true);

        // Enable player movement
        playerController.enabled = true;

        // Show TimerCanvas (but don't start the timer yet)
        timerCanvas.SetActive(true);

        // Disable CutsceneCamera
        cutsceneCamera.gameObject.SetActive(false);
    }

}
