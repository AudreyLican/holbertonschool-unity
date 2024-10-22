using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make the camera follow the player
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Private variable to store the offset distance between the Player and Camera
    private Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the camera's position to be the player's position plus the offset
        transform.position = player.transform.position + camOffset;
    }
}
